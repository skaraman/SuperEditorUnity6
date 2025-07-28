// Mock Unity classes for compilation without Unity installation
// This file provides stub implementations of Unity types to enable compilation

#if NO_UNITY

using System;
using System.Linq;

namespace UnityEngine
{
    public class Object
    {
        public static Object CreateInstance<T>() where T : Object => null;
        public HideFlags hideFlags { get; set; }
    }

    public class ScriptableObject : Object
    {
        public new static T CreateInstance<T>() where T : ScriptableObject => null;
    }

    public enum HideFlags
    {
        None = 0,
        HideInHierarchy = 1,
        HideInInspector = 2,
        DontSaveInEditor = 4,
        NotEditable = 8,
        DontSaveInBuild = 16,
        DontUnloadUnusedAsset = 32,
        DontSave = 52,
        HideAndDontSave = 61
    }

    public struct Vector2
    {
        public float x, y;
        public Vector2(float x, float y) { this.x = x; this.y = y; }
        public static Vector2 zero => new Vector2(0, 0);
        public static Vector2 one => new Vector2(1, 1);
        public static Vector2 up => new Vector2(0, 1);
        public static Vector2 down => new Vector2(0, -1);
        public static Vector2 left => new Vector2(-1, 0);
        public static Vector2 right => new Vector2(1, 0);
        
        public float magnitude => Mathf.Sqrt(x * x + y * y);
        public float sqrMagnitude => x * x + y * y;
        public Vector2 normalized => magnitude > 0 ? this / magnitude : zero;
        
        // Additional properties commonly used
        public float width => x;
        public float height => y;
        
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, float d) => new Vector2(a.x * d, a.y * d);
        public static Vector2 operator /(Vector2 a, float d) => new Vector2(a.x / d, a.y / d);
        public static bool operator ==(Vector2 lhs, Vector2 rhs) => (lhs - rhs).sqrMagnitude < 0.0001f;
        public static bool operator !=(Vector2 lhs, Vector2 rhs) => !(lhs == rhs);
        
        public override bool Equals(object obj) => obj is Vector2 other && this == other;
        public override int GetHashCode() => x.GetHashCode() ^ (y.GetHashCode() << 2);
        public override string ToString() => $"({x:F1}, {y:F1})";
    }

    public struct Vector3
    {
        public float x, y, z;
        public Vector3(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
        public static Vector3 zero => new Vector3(0, 0, 0);
        public static Vector3 one => new Vector3(1, 1, 1);
        public static Vector3 up => new Vector3(0, 1, 0);
        public static Vector3 down => new Vector3(0, -1, 0);
        public static Vector3 left => new Vector3(-1, 0, 0);
        public static Vector3 right => new Vector3(1, 0, 0);
        public static Vector3 forward => new Vector3(0, 0, 1);
        public static Vector3 back => new Vector3(0, 0, -1);
        
        public float magnitude => Mathf.Sqrt(x * x + y * y + z * z);
        public float sqrMagnitude => x * x + y * y + z * z;
        public Vector3 normalized => magnitude > 0 ? this / magnitude : zero;
        
        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator *(Vector3 a, float d) => new Vector3(a.x * d, a.y * d, a.z * d);
        public static Vector3 operator /(Vector3 a, float d) => new Vector3(a.x / d, a.y / d, a.z / d);
        public static bool operator ==(Vector3 lhs, Vector3 rhs) => (lhs - rhs).sqrMagnitude < 0.0001f;
        public static bool operator !=(Vector3 lhs, Vector3 rhs) => !(lhs == rhs);
        
        // Static utility methods
        public static Vector3 Min(Vector3 lhs, Vector3 rhs) => new Vector3(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
        public static Vector3 Max(Vector3 lhs, Vector3 rhs) => new Vector3(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
        public static float Distance(Vector3 a, Vector3 b) => (a - b).magnitude;
        public static float Dot(Vector3 lhs, Vector3 rhs) => lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs) => new Vector3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => a + (b - a) * Mathf.Clamp01(t);
        public static Vector3 Slerp(Vector3 a, Vector3 b, float t) => Lerp(a, b, t); // Simplified
        public static Vector3 Scale(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal) => inDirection - 2f * Dot(inNormal, inDirection) * inNormal;
        
        public override bool Equals(object obj) => obj is Vector3 other && this == other;
        public override int GetHashCode() => x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        public override string ToString() => $"({x:F1}, {y:F1}, {z:F1})";
    }
    
    public struct Matrix4x4
    {
        public float m00, m01, m02, m03;
        public float m10, m11, m12, m13;
        public float m20, m21, m22, m23;
        public float m30, m31, m32, m33;
        
        public static Matrix4x4 identity => new Matrix4x4
        {
            m00 = 1, m11 = 1, m22 = 1, m33 = 1
        };
        
        public static Matrix4x4 zero => new Matrix4x4();
        
        public Matrix4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            m00 = column0.x; m01 = column1.x; m02 = column2.x; m03 = column3.x;
            m10 = column0.y; m11 = column1.y; m12 = column2.y; m13 = column3.y;
            m20 = column0.z; m21 = column1.z; m22 = column2.z; m23 = column3.z;
            m30 = column0.w; m31 = column1.w; m32 = column2.w; m33 = column3.w;
        }
        
        public Vector4 GetColumn(int index) => index switch
        {
            0 => new Vector4(m00, m10, m20, m30),
            1 => new Vector4(m01, m11, m21, m31),
            2 => new Vector4(m02, m12, m22, m32),
            3 => new Vector4(m03, m13, m23, m33),
            _ => Vector4.zero
        };
        
        public Vector4 GetRow(int index) => index switch
        {
            0 => new Vector4(m00, m01, m02, m03),
            1 => new Vector4(m10, m11, m12, m13),
            2 => new Vector4(m20, m21, m22, m23),
            3 => new Vector4(m30, m31, m32, m33),
            _ => Vector4.zero
        };
        
        public float this[int row, int column]
        {
            get => (row, column) switch
            {
                (0, 0) => m00, (0, 1) => m01, (0, 2) => m02, (0, 3) => m03,
                (1, 0) => m10, (1, 1) => m11, (1, 2) => m12, (1, 3) => m13,
                (2, 0) => m20, (2, 1) => m21, (2, 2) => m22, (2, 3) => m23,
                (3, 0) => m30, (3, 1) => m31, (3, 2) => m32, (3, 3) => m33,
                _ => 0
            };
            set
            {
                switch (row, column)
                {
                    case (0, 0): m00 = value; break;
                    case (0, 1): m01 = value; break;
                    case (0, 2): m02 = value; break;
                    case (0, 3): m03 = value; break;
                    case (1, 0): m10 = value; break;
                    case (1, 1): m11 = value; break;
                    case (1, 2): m12 = value; break;
                    case (1, 3): m13 = value; break;
                    case (2, 0): m20 = value; break;
                    case (2, 1): m21 = value; break;
                    case (2, 2): m22 = value; break;
                    case (2, 3): m23 = value; break;
                    case (3, 0): m30 = value; break;
                    case (3, 1): m31 = value; break;
                    case (3, 2): m32 = value; break;
                    case (3, 3): m33 = value; break;
                }
            }
        }
    }
    
    public struct Vector4
    {
        public float x, y, z, w;
        public Vector4(float x, float y, float z, float w) { this.x = x; this.y = y; this.z = z; this.w = w; }
        public static Vector4 zero => new Vector4(0, 0, 0, 0);
        public static Vector4 one => new Vector4(1, 1, 1, 1);
        
        public float magnitude => Mathf.Sqrt(x * x + y * y + z * z + w * w);
        public float sqrMagnitude => x * x + y * y + z * z + w * w;
        public Vector4 normalized => magnitude > 0 ? this / magnitude : zero;
        
        public static Vector4 operator +(Vector4 a, Vector4 b) => new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static Vector4 operator -(Vector4 a, Vector4 b) => new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        public static Vector4 operator *(Vector4 a, float d) => new Vector4(a.x * d, a.y * d, a.z * d, a.w * d);
        public static Vector4 operator /(Vector4 a, float d) => new Vector4(a.x / d, a.y / d, a.z / d, a.w / d);
        public static bool operator ==(Vector4 lhs, Vector4 rhs) => (lhs - rhs).sqrMagnitude < 0.0001f;
        public static bool operator !=(Vector4 lhs, Vector4 rhs) => !(lhs == rhs);
        
        public override bool Equals(object obj) => obj is Vector4 other && this == other;
        public override int GetHashCode() => x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2) ^ (w.GetHashCode() >> 1);
        public override string ToString() => $"({x:F1}, {y:F1}, {z:F1}, {w:F1})";
    }

    public struct Rect
    {
        public float x, y, width, height;
        public Rect(float x, float y, float width, float height)
        {
            this.x = x; this.y = y; this.width = width; this.height = height;
        }
        
        public float xMin { get { return x; } set { width -= (value - x); x = value; } }
        public float xMax { get { return x + width; } set { width = value - x; } }
        public float yMin { get { return y; } set { height -= (value - y); y = value; } }
        public float yMax { get { return y + height; } set { height = value - y; } }
        public Vector2 center { get { return new Vector2(x + width / 2, y + height / 2); } }
        public Vector2 size { get { return new Vector2(width, height); } }
        public Vector2 position { get { return new Vector2(x, y); } }
        
        public bool Contains(Vector2 point) => point.x >= xMin && point.x < xMax && point.y >= yMin && point.y < yMax;
        public bool Overlaps(Rect other) => other.xMax > xMin && other.xMin < xMax && other.yMax > yMin && other.yMin < yMax;
    }

    public static class Mathf
    {
        public const float PI = 3.14159274f;
        public const float Deg2Rad = PI / 180f;
        public const float Rad2Deg = 180f / PI;
        public const float Epsilon = 1.401298E-45f;
        
        public static float Abs(float f) => f >= 0f ? f : -f;
        public static int Abs(int value) => value >= 0 ? value : -value;
        public static float Max(float a, float b) => a > b ? a : b;
        public static int Max(int a, int b) => a > b ? a : b;
        public static float Min(float a, float b) => a < b ? a : b;
        public static int Min(int a, int b) => a < b ? a : b;
        public static float Clamp(float value, float min, float max) => value < min ? min : (value > max ? max : value);
        public static int Clamp(int value, int min, int max) => value < min ? min : (value > max ? max : value);
        public static float Clamp01(float value) => Clamp(value, 0f, 1f);
        public static float Lerp(float a, float b, float t) => a + (b - a) * Clamp01(t);
        public static float Sin(float f) => (float)System.Math.Sin(f);
        public static float Cos(float f) => (float)System.Math.Cos(f);
        public static float Tan(float f) => (float)System.Math.Tan(f);
        public static float Sqrt(float f) => (float)System.Math.Sqrt(f);
        public static float Floor(float f) => (float)System.Math.Floor(f);
        public static float Ceil(float f) => (float)System.Math.Ceiling(f);
        public static int FloorToInt(float f) => (int)System.Math.Floor(f);
        public static int CeilToInt(float f) => (int)System.Math.Ceiling(f);
        public static int RoundToInt(float f) => (int)System.Math.Round(f);
        public static float Round(float f) => (float)System.Math.Round(f);
        public static float Pow(float f, float p) => (float)System.Math.Pow(f, p);
        public static float Log(float f) => (float)System.Math.Log(f);
        public static float Log10(float f) => (float)System.Math.Log10(f);
    }

    public struct Color32
    {
        public byte r, g, b, a;
        public Color32(byte r, byte g, byte b, byte a)
        {
            this.r = r; this.g = g; this.b = b; this.a = a;
        }
        public static implicit operator Color(Color32 c) => new Color(c.r / 255f, c.g / 255f, c.b / 255f, c.a / 255f);
        public static implicit operator Color32(Color c) => new Color32((byte)(c.r * 255), (byte)(c.g * 255), (byte)(c.b * 255), (byte)(c.a * 255));
    }

    public struct Color
    {
        public float r, g, b, a;
        public Color(float r, float g, float b, float a = 1f)
        {
            this.r = r; this.g = g; this.b = b; this.a = a;
        }
        public static Color white => new Color(1, 1, 1, 1);
        public static Color black => new Color(0, 0, 0, 1);
    }

    public class Texture2D : Object
    {
        public Texture2D(int width, int height) { }
    }

    public class GUIContent
    {
        public string text;
        public Texture2D image;
        public string tooltip;
        public GUIContent() { }
        public GUIContent(string text) { this.text = text; }
        public GUIContent(string text, Texture2D image) { this.text = text; this.image = image; }
        public GUIContent(string text, Texture2D image, string tooltip) { this.text = text; this.image = image; this.tooltip = tooltip; }
    }

    public class GUIStyle
    {
        public string name;
        public GUIStyle() { }
        public GUIStyle(string name) { this.name = name; }
    }

    public class SerializeFieldAttribute : Attribute { }

    public class MonoBehaviour : Object { }

    public class Component : Object
    {
        public GameObject gameObject { get; set; } = new GameObject("Component");
        public Transform transform { get; set; } = new Transform();
        public string tag { get; set; } = "Untagged";
        public T GetComponent<T>() where T : Component => null;
        public T GetComponentInChildren<T>() where T : Component => null;
        public T GetComponentInParent<T>() where T : Component => null;
        public T[] GetComponents<T>() where T : Component => new T[0];
        public T[] GetComponentsInChildren<T>() where T : Component => new T[0];
        public T[] GetComponentsInParent<T>() where T : Component => new T[0];
        public Component GetComponent(System.Type type) => null;
        public Component[] GetComponents(System.Type type) => new Component[0];
        public void SendMessage(string methodName, object value = null) { }
        public void SendMessageUpwards(string methodName, object value = null) { }
        public void BroadcastMessage(string methodName, object value = null) { }
        public bool CompareTag(string tag) => this.tag == tag;
    }

    public class GameObject : Object
    {
        public GameObject(string name) { }
        public T GetComponent<T>() where T : Component => null;
        public T AddComponent<T>() where T : Component => null;
    }

    public class Transform : Component
    {
        public Vector3 position { get; set; }
        public Vector3 localPosition { get; set; }
        public Vector3 eulerAngles { get; set; }
        public Vector3 localEulerAngles { get; set; }
        public Vector3 localScale { get; set; }
    }

    public class Font : Object
    {
        public Font(string name) { }
        public static Font CreateDynamicFontFromOSFont(string fontname, int size) => new Font(fontname);
    }

    public enum FontStyle
    {
        Normal = 0,
        Bold = 1,
        Italic = 2,
        BoldAndItalic = 3
    }

    public enum TextAnchor
    {
        UpperLeft = 0,
        UpperCenter = 1,
        UpperRight = 2,
        MiddleLeft = 3,
        MiddleCenter = 4,
        MiddleRight = 5,
        LowerLeft = 6,
        LowerCenter = 7,
        LowerRight = 8
    }

    public class UnityWebRequest : IDisposable
    {
        public static UnityWebRequest Get(string uri) => new UnityWebRequest();
        public void Dispose() { }
    }

    public class GenericMenu
    {
        public delegate void MenuFunction();
        public delegate void MenuFunction2(object userData);
        
        public void AddItem(GUIContent content, bool on, MenuFunction func) { }
        public void AddItem(GUIContent content, bool on, MenuFunction2 func, object userData) { }
        public void AddSeparator(string path) { }
        public void ShowAsContext() { }
    }

    public class GUILayoutOption
    {
        public static GUILayoutOption Width(float width) => new GUILayoutOption();
        public static GUILayoutOption Height(float height) => new GUILayoutOption();
        public static GUILayoutOption ExpandWidth(bool expand) => new GUILayoutOption();
        public static GUILayoutOption ExpandHeight(bool expand) => new GUILayoutOption();
    }

    public class TextAsset : Object
    {
        public string text { get; set; }
        public byte[] bytes { get; set; }
        public TextAsset(string text) { this.text = text; }
    }

    public struct Hash128
    {
        public bool isValid { get; }
        public override string ToString() => "";
    }

    public class AnimationCurve
    {
        public AnimationCurve() { }
        public AnimationCurve(params Keyframe[] keys) { }
        public Keyframe[] keys { get; set; } = new Keyframe[0];
        public int length => keys.Length;
        public WrapMode preWrapMode { get; set; }
        public WrapMode postWrapMode { get; set; }
        
        public float Evaluate(float time) => 0f;
        public int AddKey(float time, float value) => 0;
        public int AddKey(Keyframe key) => 0;
        public void RemoveKey(int index) { }
        public Keyframe this[int index] { get => new Keyframe(); set { } }
        public void SmoothTangents(int index, float weight) { }
        
        public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd) => new AnimationCurve();
        public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd) => new AnimationCurve();
        public static AnimationCurve Constant(float timeStart, float timeEnd, float value) => new AnimationCurve();
    }
    
    public struct Keyframe
    {
        public float time, value, inTangent, outTangent;
        public int tangentMode;
        public float inWeight, outWeight;
        public WeightedMode weightedMode;
        
        public Keyframe(float time, float value) 
        { 
            this.time = time; 
            this.value = value; 
            inTangent = outTangent = 0f;
            tangentMode = 0;
            inWeight = outWeight = 0f;
            weightedMode = WeightedMode.None;
        }
        
        public Keyframe(float time, float value, float inTangent, float outTangent)
        {
            this.time = time;
            this.value = value;
            this.inTangent = inTangent;
            this.outTangent = outTangent;
            tangentMode = 0;
            inWeight = outWeight = 0f;
            weightedMode = WeightedMode.None;
        }
    }
    
    public enum WrapMode
    {
        Once = 1,
        Loop = 2,
        PingPong = 4,
        ClampForever = 8
    }
    
    public enum WeightedMode
    {
        None = 0,
        In = 1,
        Out = 2,
        Both = 3
    }
    
    public struct Bounds
    {
        public Vector3 center, size;
        
        public Bounds(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = size;
        }
        
        public Vector3 min { get => center - size * 0.5f; set => SetMinMax(value, max); }
        public Vector3 max { get => center + size * 0.5f; set => SetMinMax(min, value); }
        public Vector3 extents { get => size * 0.5f; set => size = value * 2f; }
        
        public void SetMinMax(Vector3 min, Vector3 max)
        {
            extents = (max - min) * 0.5f;
            center = min + extents;
        }
        
        public void Encapsulate(Vector3 point)
        {
            SetMinMax(Vector3.Min(min, point), Vector3.Max(max, point));
        }
        
        public void Encapsulate(Bounds bounds)
        {
            Encapsulate(bounds.center - bounds.extents);
            Encapsulate(bounds.center + bounds.extents);
        }
        
        public void Expand(float amount)
        {
            amount *= 0.5f;
            extents += new Vector3(amount, amount, amount);
        }
        
        public void Expand(Vector3 amount)
        {
            extents += amount * 0.5f;
        }
        
        public bool Intersects(Bounds bounds)
        {
            return (min.x <= bounds.max.x) && (max.x >= bounds.min.x) &&
                   (min.y <= bounds.max.y) && (max.y >= bounds.min.y) &&
                   (min.z <= bounds.max.z) && (max.z >= bounds.min.z);
        }
        
        public bool IntersectRay(Ray ray) => false;
        public bool IntersectRay(Ray ray, out float distance) { distance = 0; return false; }
        public bool Contains(Vector3 point) => false;
        public float SqrDistance(Vector3 point) => 0f;
        public Vector3 ClosestPoint(Vector3 point) => point;
        
        public override string ToString() => $"Center: {center}, Extents: {extents}";
    }
    
    public struct Ray
    {
        public Vector3 origin, direction;
        
        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction.normalized;
        }
        
        public Vector3 GetPoint(float distance) => origin + direction * distance;
        
        public override string ToString() => $"Origin: {origin}, Dir: {direction}";
    }

    public interface ISerializationCallbackReceiver
    {
        void OnBeforeSerialize();
        void OnAfterDeserialize();
    }

    public class ExecuteInEditModeAttribute : Attribute { }
    public class AddComponentMenuAttribute : Attribute 
    {
        public AddComponentMenuAttribute(string menuName) { }
    }

    public class Renderer : Component 
    {
        public bool enabled { get; set; }
    }

    public class MonoScript : Object
    {
        public System.Type GetClass() => null;
    }

    public class DefaultAsset : Object
    {
    }

    public interface IHasCustomMenu
    {
        void AddItemsToMenu(GenericMenu menu);
    }

    public class MenuCommand
    {
        public Object context { get; set; }
        public int userData { get; set; }
    }

    public static class Debug
    {
        public static void Log(object message) { }
        public static void LogWarning(object message) { }
        public static void LogError(object message) { }
    }

    public static class GUILayout
    {
        public static void Label(string text) { }
        public static void Label(GUIContent content) { }
        public static bool Button(string text) => false;
        public static void BeginHorizontal() { }
        public static void EndHorizontal() { }
        public static void BeginVertical() { }
        public static void EndVertical() { }
        public static void Space(float pixels) { }
        public static void FlexibleSpace() { }
        
        // Missing GUILayout methods
        public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options) => scrollPosition;
        public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options) => scrollPosition;
        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options) => scrollPosition;
        public static void EndScrollView() { }
        public static string TextField(string text, params GUILayoutOption[] options) => text;
        public static string TextField(string label, string text, params GUILayoutOption[] options) => text;
        public static string TextArea(string text, params GUILayoutOption[] options) => text;
        public static string PasswordField(string password, char maskChar, params GUILayoutOption[] options) => password;
        public static bool Toggle(bool value, params GUILayoutOption[] options) => value;
        public static bool Toggle(string label, bool value, params GUILayoutOption[] options) => value;
        public static int Toolbar(int selected, string[] texts, params GUILayoutOption[] options) => selected;
        public static int SelectionGrid(int selected, string[] texts, int xCount, params GUILayoutOption[] options) => selected;
        public static float HorizontalSlider(float value, float leftValue, float rightValue, params GUILayoutOption[] options) => value;
        public static float VerticalSlider(float value, float topValue, float bottomValue, params GUILayoutOption[] options) => value;
        public static void Box(string text, params GUILayoutOption[] options) { }
        public static void Box(GUIContent content, params GUILayoutOption[] options) { }
        
        // Layout options factory methods
        public static GUILayoutOption Width(float width) => new GUILayoutOption();
        public static GUILayoutOption Height(float height) => new GUILayoutOption();
        public static GUILayoutOption MinWidth(float minWidth) => new GUILayoutOption();
        public static GUILayoutOption MaxWidth(float maxWidth) => new GUILayoutOption();
        public static GUILayoutOption MinHeight(float minHeight) => new GUILayoutOption();
        public static GUILayoutOption MaxHeight(float maxHeight) => new GUILayoutOption();
        public static GUILayoutOption ExpandWidth(bool expand) => new GUILayoutOption();
        public static GUILayoutOption ExpandHeight(bool expand) => new GUILayoutOption();
    }

    public static class GUI
    {
        public static void Label(Rect position, string text) { }
        public static void Label(Rect position, GUIContent content) { }
        public static bool Button(Rect position, string text) => false;
        public static string TextField(Rect position, string text) => text;
        public static Color color { get; set; }
        public static Color backgroundColor { get; set; }
        public static bool changed { get; set; }
        
        // Missing GUI methods
        public static void BeginClip(Rect position) { }
        public static void EndClip() { }
        public static void DrawTexture(Rect position, Texture2D image) { }
        public static void DrawTextureWithTexCoords(Rect position, Texture2D image, Rect texCoords) { }
        public static void Box(Rect position, string text) { }
        public static void Box(Rect position, GUIContent content) { }
        public static string PasswordField(Rect position, string password, char maskChar) => password;
        public static string TextArea(Rect position, string text) => text;
        public static bool Toggle(Rect position, bool value) => value;
        public static bool Toggle(Rect position, bool value, string text) => value;
        public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue) => value;
        public static float VerticalSlider(Rect position, float value, float topValue, float bottomValue) => value;
        public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect) => scrollPosition;
        public static void EndScrollView() { }
        public static int SelectionGrid(Rect position, int selected, string[] texts, int xCount) => selected;
        public static int SelectionGrid(Rect position, int selected, GUIContent[] content, int xCount) => selected;
        public static void BringWindowToFront(int windowID) { }
        public static void BringWindowToBack(int windowID) { }
        public static void FocusWindow(int windowID) { }
        public static void UnfocusWindow() { }
        
        // Layout properties
        public static Matrix4x4 matrix { get; set; } = Matrix4x4.identity;
        public static string tooltip { get; set; }
        public static int depth { get; set; }
        public static bool enabled { get; set; } = true;
        public static GUIStyle skin { get; set; }
    }

    public class Event
    {
        public static Event current => new Event();
        public EventType type { get; set; }
        public KeyCode keyCode { get; set; }
        public Vector2 mousePosition { get; set; }
        public Vector2 delta { get; set; } // Missing property
        public int button { get; set; }
        public bool shift { get; set; }
        public bool control { get; set; }
        public bool alt { get; set; }
        public bool command { get; set; }
        public string commandName { get; set; }
        public EventModifiers modifiers { get; set; }
        public bool isMouse => type == EventType.MouseDown || type == EventType.MouseUp || type == EventType.MouseMove || type == EventType.MouseDrag;
        public int clickCount { get; set; }
        public void Use() { }
    }

    public static class Application
    {
        public static string dataPath => "";
        public static string persistentDataPath => "";
        public static string streamingAssetsPath => "";
        public static bool isPlaying { get; set; }
        public static bool isEditor => true;
        public static string unityVersion => "6000.1.9f1";
        public static string version => "6000.1.9f1";
        public static string productName { get; set; }
        public static string companyName { get; set; }
        public static RuntimePlatform platform => RuntimePlatform.LinuxEditor;
        public static void Quit() { }
    }

    public enum RuntimePlatform
    {
        OSXEditor = 0,
        OSXPlayer = 1,
        WindowsPlayer = 2,
        WindowsEditor = 7,
        LinuxPlayer = 13,
        LinuxEditor = 16,
        Android = 11,
        IPhonePlayer = 8,
        PS4 = 19,
        XboxOne = 21,
        Switch = 38,
        WebGLPlayer = 17
    }

    public enum EventType
    {
        MouseDown = 0,
        MouseUp = 1,
        MouseMove = 2,
        MouseDrag = 3,
        KeyDown = 4,
        KeyUp = 5,
        ScrollWheel = 6,
        Repaint = 7,
        Layout = 8,
        DragUpdated = 9,
        DragPerform = 10,
        DragExited = 11,
        Ignore = 12,
        ValidateCommand = 13,
        ExecuteCommand = 14,
        ContextClick = 15,
        Used = 16,
        MouseEnterWindow = 20,
        MouseLeaveWindow = 21,
    }

    public enum KeyCode
    {
        None = 0,
        Backspace = 8,
        Delete = 127,
        Tab = 9,
        Clear = 12,
        Return = 13,
        Pause = 19,
        Escape = 27,
        Space = 32,
    }

    [System.Flags]
    public enum EventModifiers
    {
        None = 0,
        Shift = 1,
        Control = 2,
        Alt = 4,
        Command = 8,
        Numeric = 16,
        CapsLock = 32,
        FunctionKey = 64
    }
}

namespace UnityEditor
{
    public enum MessageType
    {
        None = 0,
        Info = 1,
        Warning = 2,
        Error = 3
    }

    public enum HierarchyType
    {
        Assets = 0,
        GameObjects = 1
    }

    public class EditorWindow : UnityEngine.ScriptableObject
    {
        public static T GetWindow<T>() where T : EditorWindow => null;
        public static T GetWindow<T>(string title) where T : EditorWindow => null;
        public void Show() { }
        public void ShowUtility() { }
        public void Close() { }
        public void Repaint() { }
        public string titleContent { get; set; }
        public UnityEngine.Vector2 position { get; set; }
        public UnityEngine.Vector2 minSize { get; set; }
        public UnityEngine.Vector2 maxSize { get; set; }
        
        // Missing property for Unity 6 UI Elements
        public UnityEngine.UIElements.VisualElement rootVisualElement { get; set; } = new UnityEngine.UIElements.VisualElement();
        
        protected virtual void OnGUI() { }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
        protected virtual void Update() { }
    }

    public static class EditorGUILayout
    {
        public static void LabelField(string label) { }
        public static void LabelField(string label, string value) { }
        public static string TextField(string text) => text;
        public static string TextField(string label, string text) => text;
        public static bool Button(string text) => false;
        public static void BeginHorizontal() { }
        public static void EndHorizontal() { }
        public static void BeginVertical() { }
        public static void EndVertical() { }
        public static void Space() { }
        public static bool Foldout(bool foldout, string content) => foldout;
        public static int IntField(string label, int value) => value;
        public static float FloatField(string label, float value) => value;
        public static bool Toggle(string label, bool value) => value;
        public static void HelpBox(string message, MessageType type) { }
        public static void HelpBox(string message, MessageType type, bool wide) { }
        public static UnityEngine.Rect GetControlRect(params UnityEngine.GUILayoutOption[] options) => new UnityEngine.Rect();
    }

    public static class EditorGUI
    {
        public static void LabelField(UnityEngine.Rect position, string label) { }
        public static void LabelField(UnityEngine.Rect position, string label, string value) { }
        public static string TextField(UnityEngine.Rect position, string text) => text;
        public static bool Button(UnityEngine.Rect position, string text) => false;
        public static bool Foldout(UnityEngine.Rect position, bool foldout, string content) => foldout;
        public static int IntField(UnityEngine.Rect position, string label, int value) => value;
        public static float FloatField(UnityEngine.Rect position, string label, float value) => value;
        public static bool Toggle(UnityEngine.Rect position, string label, bool value) => value;
        public static int indentLevel { get; set; }
        
        // Missing EditorGUI methods  
        public static void DrawRect(UnityEngine.Rect rect, UnityEngine.Color color) { }
        public static void BeginDisabledGroup(bool disabled) { }
        public static void EndDisabledGroup() { }
        public static void BeginChangeCheck() { }
        public static bool EndChangeCheck() => false;
        public static UnityEngine.Object ObjectField(UnityEngine.Rect position, UnityEngine.Object obj, System.Type objType, bool allowSceneObjects) => obj;
        public static UnityEngine.Object ObjectField(UnityEngine.Rect position, string label, UnityEngine.Object obj, System.Type objType, bool allowSceneObjects) => obj;
        public static T ObjectField<T>(UnityEngine.Rect position, T obj, bool allowSceneObjects) where T : UnityEngine.Object => obj;
        public static T ObjectField<T>(UnityEngine.Rect position, string label, T obj, bool allowSceneObjects) where T : UnityEngine.Object => obj;
        public static UnityEngine.Color ColorField(UnityEngine.Rect position, UnityEngine.Color value) => value;
        public static UnityEngine.Color ColorField(UnityEngine.Rect position, string label, UnityEngine.Color value) => value;
        public static UnityEngine.AnimationCurve CurveField(UnityEngine.Rect position, UnityEngine.AnimationCurve value) => value;
        public static UnityEngine.AnimationCurve CurveField(UnityEngine.Rect position, string label, UnityEngine.AnimationCurve value) => value;
        public static UnityEngine.Vector2 Vector2Field(UnityEngine.Rect position, string label, UnityEngine.Vector2 value) => value;
        public static UnityEngine.Vector3 Vector3Field(UnityEngine.Rect position, string label, UnityEngine.Vector3 value) => value;
        public static UnityEngine.Vector4 Vector4Field(UnityEngine.Rect position, string label, UnityEngine.Vector4 value) => value;
        public static UnityEngine.Rect RectField(UnityEngine.Rect position, UnityEngine.Rect value) => value;
        public static UnityEngine.Rect RectField(UnityEngine.Rect position, string label, UnityEngine.Rect value) => value;
        public static UnityEngine.Bounds BoundsField(UnityEngine.Rect position, UnityEngine.Bounds value) => value;
        public static UnityEngine.Bounds BoundsField(UnityEngine.Rect position, string label, UnityEngine.Bounds value) => value;
        public static int Popup(UnityEngine.Rect position, int selectedIndex, string[] displayedOptions) => selectedIndex;
        public static int Popup(UnityEngine.Rect position, string label, int selectedIndex, string[] displayedOptions) => selectedIndex;
        public static int Popup(UnityEngine.Rect position, int selectedIndex, UnityEngine.GUIContent[] displayedOptions) => selectedIndex;
        public static int Popup(UnityEngine.Rect position, UnityEngine.GUIContent label, int selectedIndex, UnityEngine.GUIContent[] displayedOptions) => selectedIndex;
        public static System.Enum EnumPopup(UnityEngine.Rect position, System.Enum selected) => selected;
        public static System.Enum EnumPopup(UnityEngine.Rect position, string label, System.Enum selected) => selected;
        public static int MaskField(UnityEngine.Rect position, int mask, string[] displayedOptions) => mask;
        public static int MaskField(UnityEngine.Rect position, string label, int mask, string[] displayedOptions) => mask;
        public static int LayerField(UnityEngine.Rect position, int layer) => layer;
        public static int LayerField(UnityEngine.Rect position, string label, int layer) => layer;
        public static string TagField(UnityEngine.Rect position, string tag) => tag;
        public static string TagField(UnityEngine.Rect position, string label, string tag) => tag;
        public static float Slider(UnityEngine.Rect position, float value, float leftValue, float rightValue) => value;
        public static float Slider(UnityEngine.Rect position, string label, float value, float leftValue, float rightValue) => value;
        public static int IntSlider(UnityEngine.Rect position, int value, int leftValue, int rightValue) => value;
        public static int IntSlider(UnityEngine.Rect position, string label, int value, int leftValue, int rightValue) => value;
        public static void MinMaxSlider(UnityEngine.Rect position, ref float minValue, ref float maxValue, float minLimit, float maxLimit) { }
        public static void MinMaxSlider(UnityEngine.Rect position, string label, ref float minValue, ref float maxValue, float minLimit, float maxLimit) { }
        public static string TextArea(UnityEngine.Rect position, string text) => text;
        public static string PasswordField(UnityEngine.Rect position, string password, char maskChar) => password;
        public static float KnobValue { get; set; }
        public static bool showMixedValue { get; set; }
        public static bool actionKey { get; }
        public static void DropShadowLabel(UnityEngine.Rect position, string text) { }
        public static void DropShadowLabel(UnityEngine.Rect position, UnityEngine.GUIContent content) { }
        public static void SelectableLabel(UnityEngine.Rect position, string text) { }
        public static void SelectableLabel(UnityEngine.Rect position, string text, UnityEngine.GUIStyle style) { }
        public static string DelayedTextField(UnityEngine.Rect position, string text) => text;
        public static string DelayedTextField(UnityEngine.Rect position, string label, string text) => text;
        public static int DelayedIntField(UnityEngine.Rect position, int value) => value;
        public static int DelayedIntField(UnityEngine.Rect position, string label, int value) => value;
        public static float DelayedFloatField(UnityEngine.Rect position, float value) => value;
        public static float DelayedFloatField(UnityEngine.Rect position, string label, float value) => value;
        public static void HandlePrefixLabel(UnityEngine.Rect totalPosition, UnityEngine.Rect labelPosition, UnityEngine.GUIContent label) { }
        public static void HandlePrefixLabel(UnityEngine.Rect totalPosition, UnityEngine.Rect labelPosition, UnityEngine.GUIContent label, int id) { }
    }

    public static class EditorGUIUtility
    {
        public static UnityEngine.GUIContent IconContent(string name) => new UnityEngine.GUIContent("", null, name);
        public static void PingObject(UnityEngine.Object obj) { }
        public static float singleLineHeight => 18f;
        public static float standardVerticalSpacing => 2f;
        public static string systemCopyBuffer { get; set; } = "";
    }

    public static class EditorUtility
    {
        public static void SetDirty(UnityEngine.Object target) { }
        public static bool DisplayDialog(string title, string message, string ok) => false;
        public static bool DisplayDialog(string title, string message, string ok, string cancel) => false;
        public static void DisplayProgressBar(string title, string info, float progress) { }
        public static void ClearProgressBar() { }
    }

    [System.Flags]
    public enum SelectionMode
    {
        Unfiltered = 0,
        TopLevel = 1,
        Deep = 2,
        ExcludePrefab = 4,
        Editable = 8,
        Assets = 16,
        DeepAssets = 32
    }

    public static class Selection
    {
        public static UnityEngine.Object[] objects { get; set; }
        public static UnityEngine.GameObject[] gameObjects { get; set; }
        public static UnityEngine.Object activeObject { get; set; }
        public static UnityEngine.GameObject activeGameObject { get; set; }
        public static UnityEngine.Object[] GetFiltered(System.Type type, SelectionMode selectionMode) => new UnityEngine.Object[0];
    }

    public static class Handles
    {
        public static UnityEngine.Color color { get; set; }
        public static void DrawLine(UnityEngine.Vector3 p1, UnityEngine.Vector3 p2) { }
        public static void DrawWireCube(UnityEngine.Vector3 center, UnityEngine.Vector3 size) { }
    }

    public enum PrefabType
    {
        None,
        Prefab,
        ModelPrefab,
        PrefabInstance,
        ModelPrefabInstance,
        MissingPrefabInstance,
        DisconnectedPrefabInstance,
        DisconnectedModelPrefabInstance
    }

    public enum PrefabAssetType
    {
        NotAPrefab = 0,
        Regular = 1,
        Model = 2,
        Variant = 3,
        MissingAsset = 4
    }

    public static class PrefabUtility
    {
        public static PrefabType GetPrefabType(UnityEngine.Object target) => PrefabType.None;
        public static PrefabAssetType GetPrefabAssetType(UnityEngine.Object target) => PrefabAssetType.NotAPrefab;
    }

    public class Editor
    {
        public UnityEngine.Object target { get; set; }
        public UnityEngine.Object[] targets { get; set; }
        public virtual void OnInspectorGUI() { }
        public virtual void OnSceneGUI() { }
        public virtual bool HasPreviewGUI() => false;
        public virtual void OnPreviewGUI(UnityEngine.Rect r, UnityEngine.GUIStyle background) { }
        public void Repaint() { }
    }

    public class PropertyDrawer
    {
        public virtual void OnGUI(UnityEngine.Rect position, SerializedProperty property, UnityEngine.GUIContent label) { }
        public virtual float GetPropertyHeight(SerializedProperty property, UnityEngine.GUIContent label) => 18f;
    }

    public class SerializedProperty
    {
        public string propertyPath { get; }
        public string displayName { get; }
        public SerializedPropertyType propertyType { get; }
        public bool boolValue { get; set; }
        public int intValue { get; set; }
        public float floatValue { get; set; }
        public string stringValue { get; set; }
        public UnityEngine.Vector2 vector2Value { get; set; }
        public UnityEngine.Vector3 vector3Value { get; set; }
        public UnityEngine.Color colorValue { get; set; }
        public UnityEngine.Object objectReferenceValue { get; set; }
        public bool isExpanded { get; set; }
        public bool hasMultipleDifferentValues { get; }
    }

    public enum SerializedPropertyType
    {
        Integer,
        Boolean,
        Float,
        String,
        Color,
        ObjectReference,
        LayerMask,
        Enum,
        Vector2,
        Vector3,
        Vector4,
        Rect,
        ArraySize,
        Character,
        AnimationCurve,
        Bounds,
        Generic,
    }

    public class SerializedObject
    {
        public SerializedObject(UnityEngine.Object obj) { }
        public SerializedProperty FindProperty(string propertyPath) => null;
        public void Update() { }
        public bool ApplyModifiedProperties() => false;
    }

    public class MenuItem : Attribute
    {
        public MenuItem(string itemName) { }
        public MenuItem(string itemName, bool isValidateFunction) { }
        public MenuItem(string itemName, bool isValidateFunction, int priority) { }
        
        // Constructor to handle named parameter usage like [MenuItem("path", priority = 890)]
        public string itemName { get; set; }
        public int priority { get; set; }
        public bool isValidateFunction { get; set; }
    }

    public class InitializeOnLoadAttribute : Attribute { }

    public class OnOpenAssetAttribute : Attribute
    {
        public OnOpenAssetAttribute(int order) { }
    }

    public enum PlayModeStateChange
    {
        EnteredEditMode,
        ExitingEditMode,
        EnteredPlayMode,
        ExitingPlayMode
    }

    public class AssetPostprocessor
    {
        protected virtual void OnPreprocessAsset() { }
        protected virtual void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) { }
    }

    public class CustomPropertyDrawerAttribute : Attribute
    {
        public CustomPropertyDrawerAttribute(System.Type type) { }
        public CustomPropertyDrawerAttribute(System.Type type, bool useForChildren) { }
    }

    public class UnityEventDrawer : PropertyDrawer
    {
        protected virtual void DrawEventHeader(UnityEngine.Rect headerRect) { }
    }

    public class CustomEditorAttribute : Attribute
    {
        public CustomEditorAttribute(System.Type inspectedType) { }
        public CustomEditorAttribute(System.Type inspectedType, bool editorForChildClasses) { }
    }

    public class PreferenceItemAttribute : Attribute
    {
        public PreferenceItemAttribute(string name) { }
    }

    public enum StaticEditorFlags
    {
        Nothing = 0,
        LightmapStatic = 1,
        OccluderStatic = 2,
        BatchingStatic = 4,
        NavigationStatic = 8,
        OccludeeStatic = 16,
        OffMeshLinkGeneration = 32,
        ReflectionProbeStatic = 64
    }

    namespace Compilation
    {
        public class AssemblyBuilder { }
        public class CompilationPipeline { }
        public class Assembly 
        {
            public string name { get; set; }
            public string[] defines { get; set; }
        }
    }

    namespace Callbacks
    {
        public class DidReloadScripts { }
    }

    namespace VersionControl
    {
        public class Provider 
        {
            public static Asset GetAssetByGUID(string guid) => new Asset();
            public static Task Checkout(AssetList assets, int mode) => new Task();
            public static bool CheckoutIsValid(AssetList assets) => true;
        }
        
        public class Asset
        {
            public States state { get; set; } = States.None;
            
            [System.Flags]
            public enum States
            {
                None = 0,
                AddedLocal = 1,
                AddedRemote = 2,
                CheckedOutLocal = 4,
                CheckedOutRemote = 8,
                Conflicted = 16,
                DeletedLocal = 32,
                DeletedRemote = 64,
                Exclusive = 128,
                Local = 256,
                LockedLocal = 512,
                LockedRemote = 1024,
                MetaFile = 2048,
                Missing = 4096,
                MovedLocal = 8192,
                MovedRemote = 16384,
                OutOfSync = 32768,
                ReadOnly = 65536,
                Synced = 131072,
                Unversioned = 262144,
                Updating = 524288
            }
        }
        
        public class AssetList : System.Collections.Generic.List<Asset>
        {
            public AssetList() : base() { }
            public AssetList(System.Collections.Generic.IEnumerable<Asset> collection) : base(collection) { }
            
            // Add Unity-specific methods based on documentation
            public AssetList Filter(Asset.States states) => new AssetList(this.Where(a => (a.state & states) != 0));
            public AssetList FilterChildren() => this; // Simplified stub
            public int FilterCount(Asset.States states) => this.Count(a => (a.state & states) != 0);
        }
        
        public class Task
        {
            public System.Collections.Generic.List<Message> messages { get; } = new System.Collections.Generic.List<Message>();
            public bool success { get; set; } = true;
            public void Wait() { }
            public void Dispose() { }
        }
        
        public class Message
        {
            public string text { get; set; }
            public int severity { get; set; }
            public void Show() { }
        }
    }

    namespace IMGUI
    {
        namespace Controls
        {
            public class SearchField
            {
                public string OnGUI(UnityEngine.Rect position, string text) => text;
                public string OnToolbarGUI(string text) => text;
            }
        }
    }

    public static class AssetDatabase
    {
        public static UnityEngine.Object LoadAssetAtPath(string assetPath, System.Type type) => null;
        public static T LoadAssetAtPath<T>(string assetPath) where T : UnityEngine.Object => null;
        public static string AssetPathToGUID(string assetPath) => "";
        public static string GUIDToAssetPath(string guid) => "";
        public static string GetAssetPath(UnityEngine.Object assetObject) => "";
        public static string[] FindAssets(string filter) => new string[0];
        public static string[] FindAssets(string filter, string[] searchInFolders) => new string[0];
        
        // Missing AssetDatabase methods
        public static void SaveAssets() { }
        public static void Refresh() { }
        public static void ImportAsset(string assetPath) { }
        public static void ImportAsset(string assetPath, ImportAssetOptions options) { }
        public static void DeleteAsset(string assetPath) { }
        public static string CreateAsset(UnityEngine.Object asset, string path) => path;
        public static void AddObjectToAsset(UnityEngine.Object objectToAdd, string path) { }
        public static void AddObjectToAsset(UnityEngine.Object objectToAdd, UnityEngine.Object assetObject) { }
        public static bool IsValidFolder(string path) => false;
        public static string CreateFolder(string parentFolder, string newFolderName) => "";
        public static void MoveAsset(string oldPath, string newPath) { }
        public static void RenameAsset(string pathName, string newName) { }
        public static void CopyAsset(string path, string newPath) { }
        public static string[] GetAllAssetPaths() => new string[0];
        public static UnityEngine.Object[] LoadAllAssetsAtPath(string assetPath) => new UnityEngine.Object[0];
        public static string GetAssetOrScenePath(UnityEngine.Object assetObject) => "";
        public static bool Contains(UnityEngine.Object obj) => false;
        public static bool Contains(int instanceID) => false;
        public static bool IsMainAsset(UnityEngine.Object obj) => false;
        public static bool IsSubAsset(UnityEngine.Object obj) => false;
        public static bool IsForeignAsset(UnityEngine.Object obj) => false;
        public static bool IsNativeAsset(UnityEngine.Object obj) => false;
        public static string GenerateUniqueAssetPath(string path) => path;
        public static void StartAssetEditing() { }
        public static void StopAssetEditing() { }
        public static void ReleaseCachedFileHandles() { }
        public static bool CanOpenAssetInEditor(int instanceID) => false;
        public static bool OpenAsset(int instanceID) => false;
        public static bool OpenAsset(UnityEngine.Object target) => false;
        public static UnityEngine.Hash128 GetAssetDependencyHash(string path) => new UnityEngine.Hash128();
    }
    
    [System.Flags]
    public enum ImportAssetOptions
    {
        Default = 0,
        ForceUpdate = 1,
        ForceSynchronousImport = 8,
        ImportRecursive = 256,
        DontDownloadFromCacheServer = 8192,
        ForceUncompressedImport = 16384
    }

    public class HierarchyProperty
    {
        public HierarchyProperty(HierarchyType hierarchyType) { }
        public void SetSearchFilter(string filter, int options) { }
        public void Reset() { }
        public bool Next(int[] expanded) => false;
        public string guid { get; set; } = "";
    }

    namespace UIElements
    {
        public class VisualElement { }
    }
}

namespace UnityEditorInternal
{
    public enum DllType
    {
        Unknown = 0,
        Native = 1,
        Managed = 2
    }
    
    public class InternalEditorUtility
    {
        public static void RepaintAllViews() { }
        public static DllType DetectDotNetDll(string assemblyFile) => DllType.Managed;
    }

    public class ComponentUtility
    {
        public static bool MoveComponentUp(UnityEngine.Component component) => false;
        public static bool MoveComponentDown(UnityEngine.Component component) => false;
    }

    public class ReorderableList
    {
        public delegate void ElementCallbackDelegate(UnityEngine.Rect rect, int index, bool isActive, bool isFocused);
        public delegate float ElementHeightCallbackDelegate(int index);
        
        public ReorderableList(System.Collections.IList elements, System.Type elementType, bool draggable, bool displayHeader, bool displayAddButton, bool displayRemoveButton) 
        {
            this.list = elements;
            this.elementType = elementType;
            this.draggable = draggable;
            this.displayHeader = displayHeader;
            this.displayAdd = displayAddButton;
            this.displayRemove = displayRemoveButton;
        }
        
        public void DoLayoutList() { }
        public void DoList(UnityEngine.Rect rect) { }
        
        public ElementCallbackDelegate drawElementCallback { get; set; }
        public ElementHeightCallbackDelegate elementHeightCallback { get; set; }
        
        // Missing properties
        public System.Collections.IList list { get; set; }
        public System.Type elementType { get; set; }
        public bool draggable { get; set; }
        public bool displayHeader { get; set; }
        public bool displayAdd { get; set; }
        public bool displayRemove { get; set; }
        public int index { get; set; }
        public int count => list?.Count ?? 0;
        public string headerHeight { get; set; }
        public float footerHeight { get; set; }
        public float elementHeight { get; set; } = 18f;
        
        // Callback delegates
        public System.Action<UnityEngine.Rect> drawHeaderCallback { get; set; }
        public System.Action drawFooterCallback { get; set; }
        public System.Action<int> onAddCallback { get; set; }
        public System.Action<int> onRemoveCallback { get; set; }
        public System.Action<int, int> onReorderCallback { get; set; }
        public System.Action<int> onSelectCallback { get; set; }
        public System.Func<int, bool> onCanRemoveCallback { get; set; }
        public System.Action<UnityEngine.Rect> onMouseUpCallback { get; set; }
        public System.Func<int, bool> onCanAddCallback { get; set; }
        public System.Action onChangedCallback { get; set; }
    }
}

namespace UnityEngine
{
    public class HideInInspectorAttribute : Attribute { }

    public struct RectOffset
    {
        public int left, right, top, bottom;
        public RectOffset(int left, int right, int top, int bottom)
        {
            this.left = left; this.right = right; this.top = top; this.bottom = bottom;
        }
    }

    namespace Networking
    {
        public class NetworkBehaviour : MonoBehaviour { }
    }

    namespace Events
    {
        public class UnityEvent { }
        public class UnityEvent<T> { }
        public class UnityEventBase { }
    }

    namespace SceneManagement
    {
        public static class SceneManager
        {
            public static void LoadScene(string sceneName) { }
            public static void LoadScene(int sceneBuildIndex) { }
        }

        public struct Scene
        {
            public string name { get; }
            public int buildIndex { get; }
            public bool isLoaded { get; }
        }
    }

    namespace UIElements
    {
        public class VisualElement
        {
            public string name { get; set; }
            public void Add(VisualElement child) { }
            public System.Collections.Generic.IEnumerable<VisualElement> Children() => new VisualElement[0];
            
            // Additional properties commonly used
            public UnityEngine.Vector2 contentRect { get; set; }
            public UnityEngine.Vector2 worldBound { get; set; }
            public bool visible { get; set; } = true;
            public string tooltip { get; set; }
            public object userData { get; set; }
        }

        public class IMGUIContainer : VisualElement
        {
            public System.Action onGUIHandler { get; set; }
        }
        
        public class ScrollView : VisualElement
        {
            public ScrollView() { }
            public ScrollView(ScrollViewMode scrollViewMode) { }
            public UnityEngine.Vector2 scrollOffset { get; set; }
            public float horizontalScrollerVisibility { get; set; }
            public float verticalScrollerVisibility { get; set; }
            
            // Missing properties
            public VisualElement contentViewport { get; set; } = new VisualElement();
            public VisualElement contentContainer { get; set; } = new VisualElement();
            public VisualElement horizontalScroller { get; set; } = new VisualElement();
            public VisualElement verticalScroller { get; set; } = new VisualElement();
            public ScrollViewMode mode { get; set; } = ScrollViewMode.Vertical;
            public bool showHorizontal { get; set; }
            public bool showVertical { get; set; }
            public float horizontalPageSize { get; set; } = 1f;
            public float verticalPageSize { get; set; } = 1f;
            public bool elasticAnimationIntervalMs { get; set; }
            public bool touchScrollBehavior { get; set; }
        }
        
        public enum ScrollViewMode
        {
            Vertical,
            Horizontal,
            VerticalAndHorizontal
        }

        public static class UQueryExtensions
        {
            public static T Q<T>(this VisualElement e, string name = null) where T : VisualElement => null;
            public static UQueryBuilder<T> Query<T>(this VisualElement e, string name = null) where T : VisualElement => new UQueryBuilder<T>();
            public static UQueryBuilder<VisualElement> Query(this VisualElement e, string name = null) => new UQueryBuilder<VisualElement>();
            public static UQueryBuilder<VisualElement> Query(this VisualElement e, string name, string className) => new UQueryBuilder<VisualElement>();
            public static UQueryBuilder<T> Query<T>(this VisualElement e, string name, string className) where T : VisualElement => new UQueryBuilder<T>();
        }
        
        public class UQueryBuilder<T> where T : VisualElement
        {
            public T First() => null;
            public System.Collections.Generic.List<T> ToList() => new System.Collections.Generic.List<T>();
            public void ForEach(System.Action<T> action) { }
            public UQueryBuilder<T> Where(System.Func<T, bool> predicate) => this;
            public UQueryBuilder<T> Children<U>() where U : VisualElement => new UQueryBuilder<T>();
        }

        public static class VisualElementExtensions
        {
            public static void StretchToParentSize(this VisualElement element) { }
            public static UnityEngine.Vector2 ChangeCoordinatesTo(this VisualElement src, VisualElement dest, UnityEngine.Vector2 point) => point;
            public static UnityEngine.Rect ChangeCoordinatesTo(this VisualElement src, VisualElement dest, UnityEngine.Rect rect) => rect;
        }
    }
}

#endif