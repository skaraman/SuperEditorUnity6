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
        public string name { get; set; } = "";
        
        // Missing Object methods
        public static void Destroy(Object obj) { }
        public static void DestroyImmediate(Object obj) { }
        public static void DestroyImmediate(Object obj, bool allowDestroyingAssets) { }
        public static T[] FindObjectsOfType<T>() where T : Object => new T[0];
        public static Object[] FindObjectsOfType(System.Type type) => new Object[0];
        public static T FindObjectOfType<T>() where T : Object => null;
        public static Object FindObjectOfType(System.Type type) => null;
        public static void DontDestroyOnLoad(Object target) { }
        public static Object Instantiate(Object original) => original;
        public static Object Instantiate(Object original, Transform parent) => original;
        public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace) => original;
        public static Object Instantiate(Object original, Vector3 position, Quaternion rotation) => original;
        public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent) => original;
        public static T Instantiate<T>(T original) where T : Object => original;
        public static T Instantiate<T>(T original, Transform parent) where T : Object => original;
        public static T Instantiate<T>(T original, Transform parent, bool worldPositionStays) where T : Object => original;
        public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object => original;
        public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Object => original;
        
        public override bool Equals(object other) => ReferenceEquals(this, other);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => name;
        
        public static bool operator ==(Object x, Object y) => ReferenceEquals(x, y);
        public static bool operator !=(Object x, Object y) => !ReferenceEquals(x, y);
        public static implicit operator bool(Object exists) => exists != null;
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
        public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal) => inDirection - (inNormal * (2f * Dot(inNormal, inDirection)));
        
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
    
    public struct Quaternion
    {
        public float x, y, z, w;
        
        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x; this.y = y; this.z = z; this.w = w;
        }
        
        public static Quaternion identity => new Quaternion(0, 0, 0, 1);
        
        public Vector3 eulerAngles
        {
            get
            {
                // Simplified Euler conversion
                Vector3 result = new Vector3();
                double test = x * y + z * w;
                if (test > 0.499) // singularity at north pole
                {
                    result.y = 2 * Mathf.Atan2(x, w);
                    result.z = Mathf.PI / 2;
                    result.x = 0;
                    return result * Mathf.Rad2Deg;
                }
                if (test < -0.499) // singularity at south pole
                {
                    result.y = -2 * Mathf.Atan2(x, w);
                    result.z = -Mathf.PI / 2;
                    result.x = 0;
                    return result * Mathf.Rad2Deg;
                }
                double sqx = x * x;
                double sqy = y * y;
                double sqz = z * z;
                result.y = Mathf.Atan2((float)(2 * y * w - 2 * x * z), (float)(1 - 2 * sqy - 2 * sqz));
                result.z = Mathf.Asin((float)(2 * test));
                result.x = Mathf.Atan2((float)(2 * x * w - 2 * y * z), (float)(1 - 2 * sqx - 2 * sqz));
                return result * Mathf.Rad2Deg;
            }
            set
            {
                this = Euler(value);
            }
        }
        
        public static Quaternion Euler(float x, float y, float z) => Euler(new Vector3(x, y, z));
        public static Quaternion Euler(Vector3 euler)
        {
            Vector3 radEuler = euler * Mathf.Deg2Rad * 0.5f;
            float cx = Mathf.Cos(radEuler.x);
            float sx = Mathf.Sin(radEuler.x);
            float cy = Mathf.Cos(radEuler.y);
            float sy = Mathf.Sin(radEuler.y);
            float cz = Mathf.Cos(radEuler.z);
            float sz = Mathf.Sin(radEuler.z);
            
            return new Quaternion(
                sx * cy * cz - cx * sy * sz,
                cx * sy * cz + sx * cy * sz,
                cx * cy * sz - sx * sy * cz,
                cx * cy * cz + sx * sy * sz
            );
        }
        
        public static Quaternion AngleAxis(float angle, Vector3 axis)
        {
            axis = axis.normalized;
            float halfAngle = angle * Mathf.Deg2Rad * 0.5f;
            float sin = Mathf.Sin(halfAngle);
            return new Quaternion(axis.x * sin, axis.y * sin, axis.z * sin, Mathf.Cos(halfAngle));
        }
        
        public static Quaternion LookRotation(Vector3 forward) => LookRotation(forward, Vector3.up);
        public static Quaternion LookRotation(Vector3 forward, Vector3 upwards)
        {
            // Simplified look rotation
            forward = forward.normalized;
            Vector3 right = Vector3.Cross(upwards, forward).normalized;
            upwards = Vector3.Cross(forward, right);
            
            float m00 = right.x;
            float m01 = right.y;
            float m02 = right.z;
            float m10 = upwards.x;
            float m11 = upwards.y;
            float m12 = upwards.z;
            float m20 = forward.x;
            float m21 = forward.y;
            float m22 = forward.z;
            
            float trace = m00 + m11 + m22;
            Quaternion q = new Quaternion();
            if (trace > 0)
            {
                float s = Mathf.Sqrt(trace + 1) * 2;
                q.w = 0.25f * s;
                q.x = (m21 - m12) / s;
                q.y = (m02 - m20) / s;
                q.z = (m10 - m01) / s;
            }
            else if ((m00 > m11) && (m00 > m22))
            {
                float s = Mathf.Sqrt(1 + m00 - m11 - m22) * 2;
                q.w = (m21 - m12) / s;
                q.x = 0.25f * s;
                q.y = (m01 + m10) / s;
                q.z = (m02 + m20) / s;
            }
            else if (m11 > m22)
            {
                float s = Mathf.Sqrt(1 + m11 - m00 - m22) * 2;
                q.w = (m02 - m20) / s;
                q.x = (m01 + m10) / s;
                q.y = 0.25f * s;
                q.z = (m12 + m21) / s;
            }
            else
            {
                float s = Mathf.Sqrt(1 + m22 - m00 - m11) * 2;
                q.w = (m10 - m01) / s;
                q.x = (m02 + m20) / s;
                q.y = (m12 + m21) / s;
                q.z = 0.25f * s;
            }
            return q;
        }
        
        public static float Dot(Quaternion a, Quaternion b) => a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        public static Quaternion Slerp(Quaternion a, Quaternion b, float t) => Lerp(a, b, t); // Simplified
        public static Quaternion Lerp(Quaternion a, Quaternion b, float t)
        {
            t = Mathf.Clamp01(t);
            return new Quaternion(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t,
                a.w + (b.w - a.w) * t
            ).normalized;
        }
        
        public Quaternion normalized
        {
            get
            {
                float magnitude = Mathf.Sqrt(x * x + y * y + z * z + w * w);
                if (magnitude == 0) return identity;
                return new Quaternion(x / magnitude, y / magnitude, z / magnitude, w / magnitude);
            }
        }
        
        public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion(
                lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y,
                lhs.w * rhs.y + lhs.y * rhs.w + lhs.z * rhs.x - lhs.x * rhs.z,
                lhs.w * rhs.z + lhs.z * rhs.w + lhs.x * rhs.y - lhs.y * rhs.x,
                lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z
            );
        }
        
        public static Vector3 operator *(Quaternion rotation, Vector3 point)
        {
            float x = rotation.x * 2F;
            float y = rotation.y * 2F;
            float z = rotation.z * 2F;
            float xx = rotation.x * x;
            float yy = rotation.y * y;
            float zz = rotation.z * z;
            float xy = rotation.x * y;
            float xz = rotation.x * z;
            float yz = rotation.y * z;
            float wx = rotation.w * x;
            float wy = rotation.w * y;
            float wz = rotation.w * z;
            
            return new Vector3(
                (1F - (yy + zz)) * point.x + (xy - wz) * point.y + (xz + wy) * point.z,
                (xy + wz) * point.x + (1F - (xx + zz)) * point.y + (yz - wx) * point.z,
                (xz - wy) * point.x + (yz + wx) * point.y + (1F - (xx + yy)) * point.z
            );
        }
        
        public static bool operator ==(Quaternion lhs, Quaternion rhs) => Dot(lhs, rhs) > 0.999999f;
        public static bool operator !=(Quaternion lhs, Quaternion rhs) => !(lhs == rhs);
        
        public override bool Equals(object other) => other is Quaternion q && this == q;
        public override int GetHashCode() => x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2) ^ (w.GetHashCode() >> 1);
        public override string ToString() => $"({x:F1}, {y:F1}, {z:F1}, {w:F1})";
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
        public static float Max(params float[] values) => values.Length == 0 ? 0 : values.Max();
        public static int Max(params int[] values) => values.Length == 0 ? 0 : values.Max();
        public static float Min(float a, float b) => a < b ? a : b;
        public static int Min(int a, int b) => a < b ? a : b;
        public static float Min(params float[] values) => values.Length == 0 ? 0 : values.Min();
        public static int Min(params int[] values) => values.Length == 0 ? 0 : values.Min();
        public static float Clamp(float value, float min, float max) => value < min ? min : (value > max ? max : value);
        public static int Clamp(int value, int min, int max) => value < min ? min : (value > max ? max : value);
        public static float Clamp01(float value) => Clamp(value, 0f, 1f);
        public static float Lerp(float a, float b, float t) => a + (b - a) * Clamp01(t);
        public static float Sin(float f) => (float)System.Math.Sin(f);
        public static float Cos(float f) => (float)System.Math.Cos(f);
        public static float Tan(float f) => (float)System.Math.Tan(f);
        public static float Asin(float f) => (float)System.Math.Asin(f);
        public static float Acos(float f) => (float)System.Math.Acos(f);
        public static float Atan(float f) => (float)System.Math.Atan(f);
        public static float Atan2(float y, float x) => (float)System.Math.Atan2(y, x);
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
        public static float Exp(float power) => (float)System.Math.Exp(power);
        public static float Sign(float f) => f >= 0f ? 1f : -1f;
        public static float Repeat(float t, float length) => Clamp(t - Floor(t / length) * length, 0.0f, length);
        public static float PingPong(float t, float length) => length - Abs(Repeat(t, length * 2f) - length);
        public static float InverseLerp(float a, float b, float value) => a != b ? Clamp01((value - a) / (b - a)) : 0.0f;
        public static float SmoothStep(float from, float to, float t) 
        { 
            t = Clamp01(t); 
            t = -2.0f * t * t * t + 3.0f * t * t; 
            return to * t + from * (1.0f - t); 
        }
        public static float Gamma(float value, float absmax, float gamma) => Sign(value) * Pow(Abs(value / absmax), gamma) * absmax;
        public static bool Approximately(float a, float b) => Abs(b - a) < Max(0.000001f * Max(Abs(a), Abs(b)), Epsilon * 8);
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime) => target; // Simplified
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed) => target; // Simplified
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime) => target; // Simplified
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime) => target; // Simplified
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed) => target; // Simplified
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime) => target; // Simplified
        public static float MoveTowards(float current, float target, float maxDelta) => Abs(target - current) <= maxDelta ? target : current + Sign(target - current) * maxDelta;
        public static float MoveTowardsAngle(float current, float target, float maxDelta) => MoveTowards(current, target, maxDelta); // Simplified
        public static float LerpAngle(float a, float b, float t) => a + DeltaAngle(a, b) * Clamp01(t);
        public static float DeltaAngle(float current, float target) => Repeat((target - current), 360.0f);
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
        public static Color red => new Color(1, 0, 0, 1);
        public static Color green => new Color(0, 1, 0, 1);
        public static Color blue => new Color(0, 0, 1, 1);
        public static Color yellow => new Color(1, 1, 0, 1);
        public static Color cyan => new Color(0, 1, 1, 1);
        public static Color magenta => new Color(1, 0, 1, 1);
        public static Color gray => new Color(0.5f, 0.5f, 0.5f, 1);
        public static Color grey => new Color(0.5f, 0.5f, 0.5f, 1);
        public static Color clear => new Color(0, 0, 0, 0);
        
        // Additional common color variations
        public static Color lightGray => new Color(0.7f, 0.7f, 0.7f, 1);
        public static Color darkGray => new Color(0.3f, 0.3f, 0.3f, 1);
        
        // Operators
        public static Color operator +(Color a, Color b) => new Color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
        public static Color operator -(Color a, Color b) => new Color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
        public static Color operator *(Color a, float b) => new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        public static Color operator *(Color a, Color b) => new Color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
        public static Color operator /(Color a, float b) => new Color(a.r / b, a.g / b, a.b / b, a.a / b);
        public static bool operator ==(Color lhs, Color rhs) => lhs.r == rhs.r && lhs.g == rhs.g && lhs.b == rhs.b && lhs.a == rhs.a;
        public static bool operator !=(Color lhs, Color rhs) => !(lhs == rhs);
        
        // Utility methods
        public Color gamma => new Color(Mathf.Pow(r, 2.2f), Mathf.Pow(g, 2.2f), Mathf.Pow(b, 2.2f), a);
        public Color linear => new Color(Mathf.Pow(r, 1f/2.2f), Mathf.Pow(g, 1f/2.2f), Mathf.Pow(b, 1f/2.2f), a);
        public float maxColorComponent => Mathf.Max(Mathf.Max(r, g), b);
        public float grayscale => 0.299f * r + 0.587f * g + 0.114f * b;
        
        public static Color Lerp(Color a, Color b, float t)
        {
            t = Mathf.Clamp01(t);
            return new Color(a.r + (b.r - a.r) * t, a.g + (b.g - a.g) * t, a.b + (b.b - a.b) * t, a.a + (b.a - a.a) * t);
        }
        
        public static Color HSVToRGB(float H, float S, float V) => new Color(V, V, V, 1); // Simplified
        
        public override bool Equals(object obj) => obj is Color other && this == other;
        public override int GetHashCode() => r.GetHashCode() ^ g.GetHashCode() ^ b.GetHashCode() ^ a.GetHashCode();
        public override string ToString() => $"RGBA({r:F3}, {g:F3}, {b:F3}, {a:F3})";
    }

    public class Texture2D : Object
    {
        public Texture2D(int width, int height) { this.width = width; this.height = height; }
        public Texture2D(int width, int height, TextureFormat format, bool mipChain) { this.width = width; this.height = height; }
        
        public int width { get; set; }
        public int height { get; set; }
        public TextureFormat format { get; set; } = TextureFormat.ARGB32;
        public bool isReadable { get; set; } = true;
        public FilterMode filterMode { get; set; } = FilterMode.Bilinear;
        public TextureWrapMode wrapMode { get; set; } = TextureWrapMode.Repeat;
        public int mipmapCount { get; set; } = 1;
        
        public Color GetPixel(int x, int y) => Color.white;
        public void SetPixel(int x, int y, Color color) { }
        public Color[] GetPixels() => new Color[width * height];
        public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight) => new Color[blockWidth * blockHeight];
        public void SetPixels(Color[] colors) { }
        public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors) { }
        public void Apply() { }
        public void Apply(bool updateMipmaps) { }
        public void Apply(bool updateMipmaps, bool makeNoLongerReadable) { }
        public byte[] EncodeToPNG() => new byte[0];
        public byte[] EncodeToJPG() => new byte[0];
        public byte[] EncodeToJPG(int quality) => new byte[0];
        public void LoadRawTextureData(byte[] data) { }
        public void LoadRawTextureData(System.IntPtr data, int size) { }
        public byte[] GetRawTextureData() => new byte[0];
        public void Resize(int width, int height) { this.width = width; this.height = height; }
        public void Resize(int width, int height, TextureFormat format, bool hasMipMap) { this.width = width; this.height = height; this.format = format; }
        public bool LoadImage(byte[] data) => true;
        public bool LoadImage(byte[] data, bool markNonReadable) => true;
        public void SetPixels32(Color32[] colors) { }
        public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors) { }
        public Color32[] GetPixels32() => new Color32[width * height];
        public Color32[] GetPixels32(int miplevel) => new Color32[width * height];
        public void PackTextures(Texture2D[] textures, int padding) { }
        public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize) => new Rect[0];
        public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable) => new Rect[0];
        public void ReadPixels(Rect source, int destX, int destY) { }
        public void ReadPixels(Rect source, int destX, int destY, bool recalculateMipMaps) { }
        public static Texture2D CreateExternalTexture(int width, int height, TextureFormat format, bool mipChain, bool linear, System.IntPtr nativeTex) => new Texture2D(width, height);
        
        // Static creation methods
        public static Texture2D whiteTexture => new Texture2D(1, 1);
        public static Texture2D blackTexture => new Texture2D(1, 1);
        public static Texture2D normalTexture => new Texture2D(1, 1);
        public static Texture2D redTexture => new Texture2D(1, 1);
        public static Texture2D grayTexture => new Texture2D(1, 1);
        public static Texture2D linearGrayTexture => new Texture2D(1, 1);
    }
    
    public enum TextureFormat
    {
        Alpha8 = 1,
        ARGB4444 = 2,
        RGB24 = 3,
        RGBA32 = 4,
        ARGB32 = 5,
        RGB565 = 7,
        R16 = 9,
        DXT1 = 10,
        DXT5 = 12,
        RGBA4444 = 13,
        BGRA32 = 14,
        RHalf = 15,
        RGHalf = 16,
        RGBAHalf = 17,
        RFloat = 18,
        RGFloat = 19,
        RGBAFloat = 20,
        YUY2 = 21,
        RGB9e5Float = 22,
        BC4 = 26,
        BC5 = 27,
        BC6H = 24,
        BC7 = 25,
        DXT1Crunched = 28,
        DXT5Crunched = 29,
        PVRTC_RGB2 = 30,
        PVRTC_RGBA2 = 31,
        PVRTC_RGB4 = 32,
        PVRTC_RGBA4 = 33,
        ETC_RGB4 = 34,
        EAC_R = 41,
        EAC_R_SIGNED = 42,
        EAC_RG = 43,
        EAC_RG_SIGNED = 44,
        ETC2_RGB = 45,
        ETC2_RGBA1 = 46,
        ETC2_RGBA8 = 47,
        ASTC_4x4 = 48,
        ASTC_5x5 = 49,
        ASTC_6x6 = 50,
        ASTC_8x8 = 51,
        ASTC_10x10 = 52,
        ASTC_12x12 = 53,
        RG16 = 62,
        R8 = 63,
        ETC_RGB4Crunched = 64,
        ETC2_RGBA8Crunched = 65
    }
    
    public enum FilterMode
    {
        Point = 0,
        Bilinear = 1,
        Trilinear = 2
    }
    
    public enum TextureWrapMode
    {
        Repeat = 0,
        Clamp = 1,
        Mirror = 2,
        MirrorOnce = 3
    }
    
    public enum ScaleMode
    {
        StretchToFill = 0,
        ScaleAndCrop = 1,
        ScaleToFit = 2
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
        public GUIStyle(GUIStyle other) { this.name = other.name; }
        
        // Font properties
        public Font font { get; set; }
        public int fontSize { get; set; } = 12;
        public FontStyle fontStyle { get; set; } = FontStyle.Normal;
        
        // Text properties
        public TextAnchor alignment { get; set; } = TextAnchor.UpperLeft;
        public bool wordWrap { get; set; }
        public TextClipping clipping { get; set; } = TextClipping.Clip;
        public string text { get; set; } = "";
        public Texture2D image { get; set; }
        public string tooltip { get; set; } = "";
        
        // Color properties  
        public GUIStyleState normal { get; set; } = new GUIStyleState();
        public GUIStyleState hover { get; set; } = new GUIStyleState();
        public GUIStyleState active { get; set; } = new GUIStyleState();
        public GUIStyleState focused { get; set; } = new GUIStyleState();
        public GUIStyleState onNormal { get; set; } = new GUIStyleState();
        public GUIStyleState onHover { get; set; } = new GUIStyleState();
        public GUIStyleState onActive { get; set; } = new GUIStyleState();
        public GUIStyleState onFocused { get; set; } = new GUIStyleState();
        
        // Layout properties
        public RectOffset border { get; set; } = new RectOffset(0, 0, 0, 0);
        public RectOffset margin { get; set; } = new RectOffset(0, 0, 0, 0);
        public RectOffset padding { get; set; } = new RectOffset(0, 0, 0, 0);
        public RectOffset overflow { get; set; } = new RectOffset(0, 0, 0, 0);
        
        // Size properties
        public float fixedWidth { get; set; }
        public float fixedHeight { get; set; }
        public bool stretchWidth { get; set; } = true;
        public bool stretchHeight { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        
        // Content offset
        public Vector2 contentOffset { get; set; }
        
        // Methods
        public Vector2 CalcSize(GUIContent content) => new Vector2(100, 20);
        public float CalcHeight(GUIContent content, float width) => 20f;
        public void Draw(Rect position, bool isHover, bool isActive, bool on, bool hasKeyboardFocus) { }
        public void Draw(Rect position, string text, bool isHover, bool isActive, bool on, bool hasKeyboardFocus) { }
        public void Draw(Rect position, Texture2D image, bool isHover, bool isActive, bool on, bool hasKeyboardFocus) { }
        public void Draw(Rect position, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus) { }
        public void Draw(Rect position, GUIContent content, int controlID) { }
        public void Draw(Rect position, GUIContent content, int controlID, bool on) { }
        public void DrawCursor(Rect position, GUIContent content, int controlID, int Character) { }
        public void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter) { }
        public Rect GetCursorPixelPosition(Rect position, GUIContent content, int cursorStringIndex) => position;
        public int GetCursorStringIndex(Rect position, GUIContent content, Vector2 cursorPixelPosition) => 0;
        
        // Static properties for focus window
        public static GUIStyle none { get; } = new GUIStyle();
        
        // Copy constructor helper
        public GUIStyle(GUIStyle other, string newName) : this(other) { this.name = newName; }
    }
    
    public class GUIStyleState
    {
        public Texture2D background { get; set; }
        public Color textColor { get; set; } = Color.black;
        
        // Scaled textures for different resolutions
        public Texture2D[] scaledBackgrounds { get; set; } = new Texture2D[0];
    }
    
    public enum FontStyle
    {
        Normal = 0,
        Bold = 1,
        Italic = 2,
        BoldAndItalic = 3
    }
    
    public enum TextClipping
    {
        Overflow = 0,
        Clip = 1
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
        public GameObject(string name) { this.name = name; }
        public GameObject() { this.name = "GameObject"; }
        
        public T GetComponent<T>() where T : Component => null;
        public T AddComponent<T>() where T : Component => null;
        public Component GetComponent(System.Type type) => null;
        public Component AddComponent(System.Type componentType) => null;
        public T GetComponentInChildren<T>() where T : Component => null;
        public T GetComponentInParent<T>() where T : Component => null;
        public T[] GetComponents<T>() where T : Component => new T[0];
        public Component[] GetComponents(System.Type type) => new Component[0];
        public T[] GetComponentsInChildren<T>() where T : Component => new T[0];
        public T[] GetComponentsInChildren<T>(bool includeInactive) where T : Component => new T[0];
        public Component[] GetComponentsInChildren(System.Type type) => new Component[0];
        public Component[] GetComponentsInChildren(System.Type type, bool includeInactive) => new Component[0];
        public T[] GetComponentsInParent<T>() where T : Component => new T[0];
        public T[] GetComponentsInParent<T>(bool includeInactive) where T : Component => new T[0];
        public Component[] GetComponentsInParent(System.Type type) => new Component[0];
        public Component[] GetComponentsInParent(System.Type type, bool includeInactive) => new Component[0];
        
        public void SendMessage(string methodName) { }
        public void SendMessage(string methodName, object value) { }
        public void SendMessage(string methodName, object value, SendMessageOptions options) { }
        public void SendMessage(string methodName, SendMessageOptions options) { }
        public void SendMessageUpwards(string methodName) { }
        public void SendMessageUpwards(string methodName, object value) { }
        public void SendMessageUpwards(string methodName, object value, SendMessageOptions options) { }
        public void SendMessageUpwards(string methodName, SendMessageOptions options) { }
        public void BroadcastMessage(string methodName) { }
        public void BroadcastMessage(string methodName, object parameter) { }
        public void BroadcastMessage(string methodName, object parameter, SendMessageOptions options) { }
        public void BroadcastMessage(string methodName, SendMessageOptions options) { }
        
        public Transform transform { get; set; } = new Transform();
        public int layer { get; set; } = 0;
        public bool activeSelf { get; set; } = true;
        public bool activeInHierarchy { get; set; } = true;
        public bool isStatic { get; set; } = false;
        public string tag { get; set; } = "Untagged";
        public UnityEngine.SceneManagement.Scene scene { get; set; } = new UnityEngine.SceneManagement.Scene();
        
        public void SetActive(bool value) { activeSelf = value; }
        public bool CompareTag(string tag) => this.tag == tag;
        public static GameObject FindGameObjectWithTag(string tag) => null;
        public static GameObject[] FindGameObjectsWithTag(string tag) => new GameObject[0];
        public static GameObject Find(string name) => null;
        public static GameObject CreatePrimitive(PrimitiveType type) => new GameObject("Primitive");
    }
    
    public enum SendMessageOptions
    {
        RequireReceiver = 0,
        DontRequireReceiver = 1
    }
    
    public enum PrimitiveType
    {
        Sphere = 0,
        Capsule = 1,
        Cylinder = 2,
        Cube = 3,
        Plane = 4,
        Quad = 5
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
        public static void DrawTexture(Rect position, Texture2D image, ScaleMode scaleMode, bool alphaBlend) { }
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
        public static void Focus(Rect position) { }
        
        // Layout properties
        public static Matrix4x4 matrix { get; set; } = Matrix4x4.identity;
        public static string tooltip { get; set; }
        public static int depth { get; set; }
        public static bool enabled { get; set; } = true;
        public static GUIStyle skin { get; set; }
        
        // Window and focus properties
        public static string focusedWindow { get; set; } = "";
        public static bool isProSkin { get; set; } = false;
        
        // GUI Utility methods
        public static void SetNextControlName(string name) { }
        public static string GetNameOfFocusedControl() => "";
        public static void FocusControl(string name) { }
        public static bool KeyboardEvent(Event evt) => false;
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
        public char character { get; set; } // Missing property
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
        
        // Missing Application methods
        public static void OpenURL(string url) { }
        public static bool RequestUserAuthorization(UserAuthorization mode) => false;
        public static bool HasUserAuthorization(UserAuthorization mode) => false;
        public static void RequestAdvertisingIdentifierAsync(AdvertisingIdentifierCallback delegateMethod) { }
        public static void LogCallback(string condition, string stackTrace, LogType type) { }
        public static void LogCallbackThreaded(string condition, string stackTrace, LogType type) { }
        public static void CancelQuit() { }
        public static bool CanStreamedLevelBeLoaded(int levelIndex) => false;
        public static bool CanStreamedLevelBeLoaded(string levelName) => false;
        public static string[] GetBuildTags() => new string[0];
        public static void SetBuildTags(string[] buildTags) { }
        public static bool HasProLicense() => false;
        public static void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType) { }
        public static StackTraceLogType GetStackTraceLogType(LogType logType) => StackTraceLogType.ScriptOnly;
        public static void ExternalCall(string functionName, params object[] args) { }
        public static void ExternalEval(string script) { }
        public static bool focusedWindow { get; set; } = false;
        public static SystemLanguage systemLanguage => SystemLanguage.English;
        public static int targetFrameRate { get; set; } = -1;
        public static bool runInBackground { get; set; } = true;
        public static ThreadPriority backgroundLoadingPriority { get; set; } = ThreadPriority.Low;
        public static int internetReachability => 0;
        public static bool genuineCheckAvailable => false;
        public static bool genuine => true;
        public static NetworkReachability internetReachability2 => NetworkReachability.NotReachable;
    }
    
    public delegate void AdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled, string errorMessage);
    
    public enum UserAuthorization
    {
        Microphone = 0,
        WebCam = 1
    }
    
    public enum LogType
    {
        Error = 0,
        Assert = 1,
        Warning = 2,
        Log = 3,
        Exception = 4
    }
    
    public enum StackTraceLogType
    {
        None = 0,
        ScriptOnly = 1,
        Full = 2
    }
    
    public enum SystemLanguage
    {
        Afrikaans = 0,
        Arabic = 1,
        Basque = 2,
        Belarusian = 3,
        Bulgarian = 4,
        Catalan = 5,
        Chinese = 6,
        Czech = 7,
        Danish = 8,
        Dutch = 9,
        English = 10,
        Estonian = 11,
        Faroese = 12,
        Finnish = 13,
        French = 14,
        German = 15,
        Greek = 16,
        Hebrew = 17,
        Hungarian = 18,
        Icelandic = 19,
        Indonesian = 20,
        Italian = 21,
        Japanese = 22,
        Korean = 23,
        Latvian = 24,
        Lithuanian = 25,
        Norwegian = 26,
        Polish = 27,
        Portuguese = 28,
        Romanian = 29,
        Russian = 30,
        SerboCroatian = 31,
        Slovak = 32,
        Slovenian = 33,
        Spanish = 34,
        Swedish = 35,
        Thai = 36,
        Turkish = 37,
        Ukrainian = 38,
        Vietnamese = 39,
        Unknown = 40
    }
    
    public enum ThreadPriority
    {
        Low = 0,
        BelowNormal = 1,
        Normal = 2,
        High = 4
    }
    
    public enum NetworkReachability
    {
        NotReachable = 0,
        ReachableViaCarrierDataNetwork = 1,
        ReachableViaLocalAreaNetwork = 2
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
        private static readonly System.Collections.Generic.Dictionary<string, UnityEngine.Texture2D> _iconCache = 
            new System.Collections.Generic.Dictionary<string, UnityEngine.Texture2D>();
            
        public static UnityEngine.GUIContent IconContent(string name) => new UnityEngine.GUIContent("", null, name);
        public static UnityEngine.GUIContent ObjectContent(UnityEngine.Object obj, System.Type type)
        {
            // When running with mock Unity (no actual Unity installation), provide appropriate fallback icons
            string typeName = "";
            
            if (obj != null)
            {
                typeName = obj.GetType().Name;
            }
            else if (type != null)
            {
                typeName = type.Name;
            }
            
            // Create a simple texture for common Unity component types to avoid question mark icons
            var texture = CreateFallbackIcon(typeName);
            return new UnityEngine.GUIContent(typeName, texture, $"Mock {typeName} component");
        }
        
        private static UnityEngine.Texture2D CreateFallbackIcon(string typeName)
        {
            // Check cache first to avoid recreating textures
            if (_iconCache.TryGetValue(typeName, out var cachedTexture))
            {
                return cachedTexture;
            }
            
            try
            {
                // Create a simple 16x16 colored square as fallback icon instead of question mark
                var texture = new UnityEngine.Texture2D(16, 16);
                var color = GetColorForType(typeName);
                
                // Fill the texture with the color
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        texture.SetPixel(x, y, color);
                    }
                }
                
                texture.Apply();
                
                // Cache the texture for future use
                _iconCache[typeName] = texture;
                return texture;
            }
            catch
            {
                // If texture creation fails, return null so the system can use its normal fallback
                return null;
            }
        }
        
        private static UnityEngine.Color GetColorForType(string typeName)
        {
            // Provide different colors for different component types to make them distinguishable
            return typeName switch
            {
                "Transform" => UnityEngine.Color.blue,
                "Renderer" => UnityEngine.Color.green,
                "MeshRenderer" => UnityEngine.Color.green,
                "Camera" => UnityEngine.Color.cyan,
                "Light" => UnityEngine.Color.yellow,
                "AudioSource" => UnityEngine.Color.magenta,
                "Rigidbody" => UnityEngine.Color.red,
                "Collider" => UnityEngine.Color.gray,
                "MonoBehaviour" => UnityEngine.Color.white,
                _ => UnityEngine.Color.lightGray // Default fallback color
            };
        }
        
        public static void PingObject(UnityEngine.Object obj) { }
        public static float singleLineHeight => 18f;
        public static float standardVerticalSpacing => 2f;
        public static string systemCopyBuffer { get; set; } = "";
        public static void SetIconSize(UnityEngine.Vector2 size) { }
        public static int GetObjectPickerControlID() => 332553;
        public static UnityEngine.Object GetObjectPickerObject() => null;
        public static bool isProSkin => false;
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
        
        public static bool IsPersistantListenerValid(UnityEngine.Events.UnityEventBase unityEvent, string methodName, UnityEngine.Object target, UnityEngine.Events.PersistentListenerMode mode, System.Type argumentType)
        {
            // Mock implementation - always return true for compilation
            return true;
        }
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
            public string outputPath { get; set; } = "";
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

    // Font import related classes for Unity 6 compatibility
    public class AssetImporter : UnityEngine.Object
    {
        public static AssetImporter GetAtPath(string assetPath) => null;
    }

    public enum FontRenderingMode
    {
        OSDefault = 0,
        Smooth = 1,
        HintedSmooth = 2,
        HintedRaster = 3
    }

    public class TrueTypeFontImporter : AssetImporter
    {
        public FontRenderingMode fontRenderingMode { get; set; } = FontRenderingMode.Smooth;
        public int fontSize { get; set; } = 16;
    }

    // Legacy alias for backward compatibility
    public class FontImporter : TrueTypeFontImporter
    {
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
        
        public enum PersistentListenerMode
        {
            EventDefined = 0,
            Void = 1,
            Object = 2,
            Int = 3,
            Float = 4,
            String = 5,
            Bool = 6
        }
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