// Mock Unity classes for compilation without Unity installation
// This file provides stub implementations of Unity types to enable compilation

#if NO_UNITY

using System;

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

    public class Component : Object { }

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
    }

    public class Event
    {
        public static Event current => new Event();
        public EventType type { get; set; }
        public KeyCode keyCode { get; set; }
        public Vector2 mousePosition { get; set; }
        public int button { get; set; }
        public bool shift { get; set; }
        public bool control { get; set; }
        public bool alt { get; set; }
        public bool command { get; set; }
        public string commandName { get; set; }
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
        MouseDown,
        MouseUp,
        MouseMove,
        MouseDrag,
        KeyDown,
        KeyUp,
        ScrollWheel,
        Repaint,
        Layout,
        DragUpdated,
        DragPerform,
        DragExited,
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
        public static bool indentLevel { get; set; }
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

    public static class Selection
    {
        public static UnityEngine.Object[] objects { get; set; }
        public static UnityEngine.GameObject[] gameObjects { get; set; }
        public static UnityEngine.Object activeObject { get; set; }
        public static UnityEngine.GameObject activeGameObject { get; set; }
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
        public class Provider { }
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
        
        public ReorderableList(System.Collections.IList elements, System.Type elementType, bool draggable, bool displayHeader, bool displayAddButton, bool displayRemoveButton) { }
        public void DoLayoutList() { }
        public void DoList(UnityEngine.Rect rect) { }
        
        public ElementCallbackDelegate drawElementCallback { get; set; }
        public ElementHeightCallbackDelegate elementHeightCallback { get; set; }
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
            public System.Collections.Generic.IEnumerable<VisualElement> Children => new VisualElement[0];
        }

        public class IMGUIContainer : VisualElement
        {
            public System.Action onGUIHandler { get; set; }
        }

        public static class UQueryExtensions
        {
            public static T Q<T>(this VisualElement e, string name = null) where T : VisualElement => null;
        }

        public static class VisualElementExtensions
        {
            public static void StretchToParentSize(this VisualElement element) { }
        }
    }
}

#endif