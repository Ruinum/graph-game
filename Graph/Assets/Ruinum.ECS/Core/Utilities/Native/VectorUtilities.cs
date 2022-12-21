using System;
using Ruinum.ECS.Configurations;
using Ruinum.ECS.Extensions;
using UnityEngine;

namespace Ruinum.ECS.Utilities
{
    public static class VectorUtilities
    {
        public static Vector3 PlaneIntersection(Vector3 planeOffset, Vector3 planeNormal, Vector3 point, Vector3 direction)
        {
            var ray = new Ray(point, direction);
            new Plane(planeNormal, planeOffset).Raycast(ray, out var result);
            return ray.GetPoint(result);
        } 
        
        public static Vector3 SetAxisFromVector(Vector3 to, Vector3 from, Vector3Axis axis)
        {
            switch (axis)
            {
                case Vector3Axis.X: to.x = from.x; break;
                case Vector3Axis.Y: to.y = from.y; break;
                case Vector3Axis.Z: to.z = from.z; break;
                default: throw new ArgumentOutOfRangeException(nameof(axis), $"Unknown axis of enum {nameof(Vector3Axis)}");
            }
            return to;
        }

        public static Vector3 TrimAxis(Vector3 vector, Vector3Axis axis)
        {
            SetAxisFromVector(vector, Vector3.zero, axis);
            return vector;
        }

        public static float GetLocalDirectionAxisValue(Vector3Axis axis, Vector3 vector, Vector3 position, Quaternion rotation)
        {
            return default; //GetAxisValue(axis, vector.InverseTransformDirection(position, rotation));
        }

        public static float GetLocalPointAxisValue(Vector3Axis axis, Vector3 vector, Vector3 position, Quaternion rotation)
        {
            return default; //GetAxisValue(axis, vector.InverseTransformPoint(position, rotation));
        }

        public static Vector3 SetAxisValue(Vector3Axis axis, Vector3 vector, float value)
        {
            switch (axis)
            {
                case Vector3Axis.X: vector.x = value; break;
                case Vector3Axis.Y: vector.y = value; break;
                case Vector3Axis.Z: vector.z = value; break;
                default: throw new ArgumentOutOfRangeException(nameof(axis), axis, "Unknown axis " + axis);
            }
            return vector;
        }

        public static float GetAxisValue(Vector3Axis axis, Vector3 vector)
        {
            switch (axis)
            {
                case Vector3Axis.X: return vector.x;
                case Vector3Axis.Y: return vector.y;
                default: return vector.z;
            }
        }

        public static float GetOrientationAxisSign(SignOrientationAxis signOrientationAxis, Vector3 pointFrom, Quaternion fromQuaternion, Vector3 pointTo)
        {
            return default; // Mathf.Sign(GetAxisValue(signOrientationAxis, pointTo.InverseTransformPoint(pointFrom, fromQuaternion)));
        }

        public static float GetAxisValue(SignOrientationAxis signOrientationAxis, Vector3 point)
        {
            switch (signOrientationAxis)
            {
                case SignOrientationAxis.X: return point.x;
                case SignOrientationAxis.Z: return point.z;
                case SignOrientationAxis.Y: return point.y;
                default: return 1;
            }
        }

        public static Vector3 GetSurfaceParallel(Vector3 surfaceNormal, Vector3 direction)
        {
            return (direction - surfaceNormal * Vector3.Dot(direction, surfaceNormal)).normalized;
        }

        public static float FullCircleAngle(Vector3 from, Vector3 to, Vector3 axis)
        {
            var angle = Vector3.SignedAngle(from, to, Vector3.up);
            if (angle < 0)
            {
                angle = 360 + angle;
            }
            return angle;
        }

        public static Vector3 Scale(Vector3 a, float x, float y, float z)
        {
            return new Vector3(a.x * x, a.y * y, a.z * z);
        }

        public static Vector3 InverseTransformPoint(Vector3 point, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            var scaleVector = new Vector3(1 / localScale.x, 1 / localScale.y, 1 / localScale.z);
            return Vector3.Scale(scaleVector, (Quaternion.Inverse(localRotation) * (point - localPosition)));
        }

        public static Vector3 TransformPoint(Vector3 point, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            return Matrix(localPosition, localRotation, localScale).MultiplyPoint3x4(point);
        }

        public static Vector3 InverseTransformDirection(Vector3 direction, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            return Matrix(localPosition, localRotation, localScale).transpose.MultiplyVector(direction);
        }

        public static Vector3 TransformDirection(Vector3 direction, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            return Matrix(localPosition, localRotation, localScale).MultiplyVector(direction);
        }

        public static Vector3 InverseTransformPoint(Vector3 point, Vector3 localPosition, Quaternion localRotation)
        {
            return InverseTransformPoint(point, localPosition, localRotation, Vector3.one);
        }

        public static Vector3 TransformPoint(Vector3 point, Vector3 localPosition, Quaternion localRotation)
        {
            return TransformPoint(point, localPosition, localRotation, Vector3.one) ;
        }

        public static Vector3 InverseTransformDirection(Vector3 direction, Vector3 localPosition, Quaternion localRotation)
        {
            return InverseTransformDirection(direction, localPosition, localRotation, Vector3.one);
        }

        public static Vector3 TransformDirection(Vector3 direction, Vector3 localPosition, Quaternion localRotation)
        {
            return TransformDirection(direction, localPosition, localRotation, Vector3.one);
        }

        public static Matrix4x4 Matrix(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            return Matrix4x4.TRS(position, rotation.normalized, scale);
        }
    }
}