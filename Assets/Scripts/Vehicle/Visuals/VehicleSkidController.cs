using UnityEngine;
using UnityEngine.Rendering;

namespace Vehicle.Visuals
{
    public class VehicleSkidController : MonoBehaviour
    {
        [SerializeField] Material skidmarkMaterial;

        static VehicleSkidController _instance;
        public static VehicleSkidController Instance
        {
            get
            {
                if(_instance == null) Debug.Log("VehicleSkidController is null");
                return _instance;
            }
        }


        public int globalMaxMarks = 2048;
        public float markWidth = 0.35f;
        public float groundOffset = 0.02f;
        public float minDistance = 0.25f;
        public float maxOpacity = 1.0f;

        public int markIndex;

        public MarkSection[] skidmarks;
        public MeshFilter meshFilter;
        public MeshRenderer meshRenderer;
        public Mesh marksMesh;

        public Vector3[] vertices;
        public Vector3[] normals;
        public Vector4[] tangents;
        public Color32[] colors;
        public Vector2[] uvs;
        public int[] triangles;

        Color markColor = Color.black;

        bool meshUpdated = true;
        bool haveSetBounds = false;

        public class MarkSection
        {
            public Vector3 pos = Vector3.zero;
            public Vector3 normal = Vector3.zero;
            public Vector3 tangent = Vector3.zero;
            public Vector3 posL = Vector3.zero;
            public Vector3 posR = Vector3.zero;
            public Color32 color;
            public int lastIndex;
        }

        void Awake()
        {
            _instance = this;
            this.transform.position = Vector3.zero;
            this.transform.rotation = Quaternion.identity;
        }

        void Start()
        {
            skidmarks = new MarkSection[globalMaxMarks];

            for (int i = 0; i < globalMaxMarks; i++)
            {
                skidmarks[i] = new MarkSection();
            }

            meshFilter = GetComponent<MeshFilter>();
            meshRenderer = GetComponent<MeshRenderer>();

            marksMesh = new Mesh();
            marksMesh.MarkDynamic();

            meshFilter.sharedMesh = marksMesh;

            vertices = new Vector3[globalMaxMarks * 4];
            normals = new Vector3[globalMaxMarks * 4];
            tangents = new Vector4[globalMaxMarks * 4];
            colors = new Color32[globalMaxMarks * 4];
            uvs = new Vector2[globalMaxMarks * 4];
            triangles = new int[globalMaxMarks * 6];

            meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
            meshRenderer.receiveShadows = false;
            meshRenderer.material = skidmarkMaterial;
            meshRenderer.lightProbeUsage = LightProbeUsage.Off;
        }

        void LateUpdate()
        {
            //Necessary?

            if(!meshUpdated) return;
            meshUpdated = false;

            marksMesh.vertices = vertices;
            marksMesh.normals = normals;
            marksMesh.tangents = tangents;
            marksMesh.triangles = triangles;
            marksMesh.colors32 = colors;
            marksMesh.uv = uvs;

            if(!haveSetBounds)
            {
                //Draw Distance
                marksMesh.bounds = new Bounds(Vector3.zero, new Vector3(10000, 10000, 10000));
                haveSetBounds = true;
            }

            meshFilter.sharedMesh = marksMesh;
        }

        public int AddSkidMark(Vector3 point, Vector3 normal, float opacity, int lastIndex)
        { 
        

        
            MarkSection lastMarkSection = null;
            Vector3 distanceDirection = Vector3.zero;
            Vector3 newPosition = point + normal * groundOffset;

            if(lastIndex != -1)
            {
                lastMarkSection = skidmarks[lastIndex];
                distanceDirection = newPosition - lastMarkSection.pos;
                if(distanceDirection.sqrMagnitude < minDistance) // if this mark is still too close to last mark, skip
                {
                    return lastIndex;
                }
            
                if(distanceDirection.sqrMagnitude > minDistance * 10) // Weird result,  ignore
                {
                    lastIndex = -1;
                    lastMarkSection = null;
                }
            }
            MarkSection currentSection = skidmarks[markIndex];

        
            currentSection.pos = newPosition;
            currentSection.normal = normal;
            currentSection.color = markColor;
            currentSection.lastIndex = lastIndex;
            markColor = new Color32(0,0,0,(byte)(opacity * 255 * maxOpacity));
            currentSection.color = markColor;
        
            if (lastMarkSection != null)
            {
                Vector3 xDirection = Vector3.Cross(distanceDirection, normal).normalized; // get x axis
                currentSection.posL = currentSection.pos + xDirection * markWidth * 0.5f;
                currentSection.posR = currentSection.pos - xDirection * markWidth * 0.5f;
                currentSection.tangent = new Vector4(xDirection.x, xDirection.y, xDirection.z, 1);

                if(lastMarkSection.lastIndex == -1)
                {
                    lastMarkSection.tangent = currentSection.tangent;
                    lastMarkSection.posL = currentSection.pos + xDirection * markWidth * 0.5f;
                    lastMarkSection.posR = currentSection.pos - xDirection * markWidth * 0.5f;
                }   
            }

            UpdateSkidmarksMesh();

            int currentIndex = markIndex;

            markIndex = ++markIndex % globalMaxMarks;

            return currentIndex;
        }


        /* Adjusts Alpha, why is this a separate overload function??
    public int AddSkidMark(Vector3 point, Vector3 normal, float opacity, int lastIndex)
    {
        if(opacity > 1) opacity = 1.0f;
        else if (opacity < 0) return -1;

        markColor.a = (byte)(opacity * 255);
        return AddSkidMark(point, normal, markColor, lastIndex);
    }

    public int AddSkidMark(Vector3 point, Vector3 normal, Color32 color, int lastIndex)
    {
        if(color.a == 0) return -1; //Why would it get here if it were 0??

        MarkSection lastMarkSection = null;
        Vector3 distanceDirection = Vector3.zero;
        Vector3 newPosition = point + normal * groundOffset;

        if(lastIndex != -1)
        {
            lastMarkSection = skidmarks[lastIndex];
            distanceDirection = newPosition - lastMarkSection.pos;
            if(distanceDirection.sqrMagnitude < minDistance)
            {
                return lastIndex;
            }
            
            if(distanceDirection.sqrMagnitude > minDistance * 10)
            {
                lastIndex = -1;
                lastMarkSection = null;
            }
        }

        color.a = (byte)(color.a * maxOpacity);

        MarkSection currentSection = skidmarks[markIndex];

        currentSection.pos = newPosition;
        currentSection.normal = normal;
        currentSection.color = color;
        currentSection.lastIndex = lastIndex;

        
    }*/

        void UpdateSkidmarksMesh()
        {
            MarkSection currentSection = skidmarks[markIndex];

            if (currentSection.lastIndex == -1) return;

            MarkSection lastMarkSection = skidmarks[currentSection.lastIndex];

            UpdateMeshIndex(vertices, markIndex, lastMarkSection.posL, lastMarkSection.posR, 
                currentSection.posL, currentSection.posR);
            UpdateMeshIndex(normals, markIndex, lastMarkSection.normal, lastMarkSection.normal, 
                currentSection.normal, currentSection.normal);
            UpdateMeshIndex(tangents, markIndex, lastMarkSection.tangent, lastMarkSection.tangent, 
                currentSection.tangent, currentSection.tangent);
            UpdateMeshIndex(colors, markIndex, lastMarkSection.color, lastMarkSection.color, 
                currentSection.color, currentSection.color);
            UpdateMeshIndex(uvs, markIndex);
            UpdateMeshIndex(triangles, markIndex);

            meshUpdated = true;
        }
    
        void UpdateMeshIndex(int[] array, int index)
        {
            int indexR = index * 4;
            index *= 6;
        
            array[index] = indexR;
            array[index + 1] = indexR + 2;
            array[index + 2] = indexR + 1;
            array[index + 3] = indexR + 2;
            array[index + 4] = indexR + 3;
            array[index + 5] = indexR + 1;
        }
        void UpdateMeshIndex(Vector2[] array, int index)
        {
            index *= 4;
            array[index] = new Vector2(0, 0);
            array[index + 1] = new Vector2(1, 0);
            array[index + 2] = new Vector2(0, 1);
            array[index + 3] = new Vector2(1, 1);
        }
        void UpdateMeshIndex(Vector3[] array, int index, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            index *= 4;
            array[index] = a;
            array[index + 1] = b;
            array[index + 2] = c;
            array[index + 3] = d;
        }
        void UpdateMeshIndex(Vector4[] array, int index, Vector4 a, Vector4 b, Vector4 c, Vector4 d)
        {
            index *= 4;
            array[index] = a;
            array[index + 1] = b;
            array[index + 2] = c;
            array[index + 3] = d;
        }
        void UpdateMeshIndex(Color32[] array, int index, Color32 a, Color32 b, Color32 c, Color32 d)
        {
            index *= 4;
            array[index] = a;
            array[index + 1] = b;
            array[index + 2] = c;
            array[index + 3] = d;
        }
    }
}
