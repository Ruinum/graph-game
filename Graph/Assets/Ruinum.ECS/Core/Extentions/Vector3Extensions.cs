using Ruinum.ECS.Utilities;
using UnityEngine;

namespace Ruinum.ECS.Extensions
{
    public static class Vector3Extensions
    {
        public static readonly Vector3 VetricalTrimmedOne = new Vector3(1, 0, 1);
        public static readonly Vector3 XZTrimmedOne = new Vector3(0, 1, 0);
        public static readonly Vector3 YZTrimmedOne = new Vector3(1, 0, 0);

        public static Vector3 GetScaled(this Vector3 sourceVector, Vector3 scaleVector)
        {
            return Vector3.Scale(sourceVector, scaleVector);
        }

        public static Vector3 GetScaledXZ(this Vector3 sourceVector)
        {
            return Vector3.Scale(sourceVector, XZTrimmedOne);
        }
        
        public static Vector3 GetScaledYZ(this Vector3 sourceVector)
        {
            return Vector3.Scale(sourceVector, YZTrimmedOne);
        }

        public static Vector3 GetScaled(this Vector3 sourceVector, float x, float y, float z)
        {
            return VectorUtilities.Scale(sourceVector, x, y, z);
        }

        public static Vector3 GetScaledVertical(this Vector3 sourceVector)
        {
            return Vector3.Scale(sourceVector, VetricalTrimmedOne);
        }

        public static Vector3 InverseTransformPoint(this Vector3 point, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            return VectorUtilities.InverseTransformPoint(point, localPosition, localRotation, localScale);
        }

        public static Vector3 TransformPosition(this Vector3 point, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            return VectorUtilities.TransformPoint(point, localPosition, localRotation, localScale);
        }

        public static Vector3 InverseTransformDirection(this Vector3 direction, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            return VectorUtilities.InverseTransformDirection(direction, localPosition, localRotation, localScale);
        }

        public static Vector3 TransformDirection(this Vector3 direction, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            return VectorUtilities.TransformDirection(direction, localPosition, localRotation, localScale);
        }

        public static Vector3 InverseTransformPoint(this Vector3 point, Vector3 localPosition, Quaternion localRotation)
        {
            return VectorUtilities.InverseTransformPoint(point, localPosition, localRotation);
        }

        public static Vector3 TransformPosition(this Vector3 point, Vector3 localPosition, Quaternion localRotation)
        {
            return VectorUtilities.TransformPoint(point, localPosition, localRotation);
        }

        public static Vector3 InverseTransformDirection(this Vector3 direction, Vector3 localPosition, Quaternion localRotation)
        {
            return VectorUtilities.InverseTransformDirection(direction, localPosition, localRotation);
        }

        public static Vector3 TransformDirection(this Vector3 direction, Vector3 localPosition, Quaternion localRotation)
        {
            return VectorUtilities.TransformDirection(direction, localPosition, localRotation);
        }
    }
}