using UnityEngine;

namespace Scripts.Utils
{
    /// <summary>
    /// Simulates the touch screen hold using the get mouse button (0) 'left click'. 
    /// </summary>
    public static class TouchSimulator
    {

        private static float pastPosition;


        /// <summary>
        /// Simulates a Touch screen hold by mouse button 0 (left click) and its position in X Axis. 
        /// Updates the game object transform. Must be called in update method;
        /// </summary>
        /// <param name="transform">The transform of the game object to simulate</param>
        /// <param name="moveSpeed">The speed to 'Drag' the game object</param>
        public static void MoveInAbscissaByTouchSimulation(Transform transform, float moveSpeed)
        {
            if(Input.GetMouseButton(0))
            {
                transform.position += Vector3.right * getTouchAbscissaDelta() * moveSpeed * Time.deltaTime;
            }
            SaveLastMousePositionInAbscissa();
        }
        /// <summary>
        /// Returns a float delta (number of changes) of the mouse position in x Axis
        /// </summary>
        /// <returns>The difference of the current mouse position minus its last position</returns>
        private static float getTouchAbscissaDelta()
        {
            float xPositionDelta = Input.mousePosition.x - pastPosition;
            return xPositionDelta;
        }
        private static void SaveLastMousePositionInAbscissa()
        {
            pastPosition = Input.mousePosition.x;
        }

    }
}
