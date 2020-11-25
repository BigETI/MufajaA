using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Physics utilities
    /// </summary>
    public static class PhysicsUtilities
    {
        /// <summary>
        /// Minimal allocation length
        /// </summary>
        private static uint minimalAllocationLength = 128U;

        /// <summary>
        /// Gets colliders that overlap with the specified circle
        /// </summary>
        /// <param name="point">Point</param>
        /// <param name="radius">Radius</param>
        /// <param name="results">Results</param>
        /// <returns>Number of colliders overlapping with the specified circle</returns>
        public static int CircleOverlapAll(Vector2 point, float radius, ref Collider2D[] results)
        {
            int ret = 0;
            bool keep_checking = true;
            results = results ?? new Collider2D[minimalAllocationLength];
            if (results.Length < minimalAllocationLength)
            {
                results = new Collider2D[minimalAllocationLength];
            }
            while (keep_checking)
            {
                ret = Physics2D.OverlapCircleNonAlloc(point, radius, results);
                keep_checking = (ret >= results.Length);
                if (keep_checking)
                {
                    results = new Collider2D[results.Length * 2];
                }
            }
            return ret;
        }
    }
}
