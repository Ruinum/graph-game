using UnityEngine;

namespace Ruinum.ECS.Utilities
{
    public static class QuaternionUtilities
    {
        public static Quaternion LerpShortWay(Quaternion p, Quaternion q, float t)
        {
            while (true)
            {
                var dot = Quaternion.Dot(p, q);
                if (dot < 0.0f)
                {
                    p = ScalarMultiply(p, -1.0f);
                    continue;
                }
                var r = Quaternion.identity;
                r.x = p.x * (1f - t) + q.x * (t);
                r.y = p.y * (1f - t) + q.y * (t);
                r.z = p.z * (1f - t) + q.z * (t);
                r.w = p.w * (1f - t) + q.w * (t);
                return r;
            }
        }

        private static Quaternion ScalarMultiply(Quaternion input, float scalar)
        {
            return new Quaternion(input.x * scalar, input.y * scalar, input.z * scalar, input.w * scalar);
        }
    }

}