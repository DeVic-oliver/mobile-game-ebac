using UnityEngine;

namespace Scripts.Utils
{

    /// <summary>
    /// Parses if the game object is touching the ground. The Ground needs to be targeted with a 'Layer Mask' named 'Ground'
    /// </summary>

    public static class JumpRaycaster
    {
        private static string _mask = "Ground";

        /// <summary>
        /// Fires a ray from the middle of the gameobject that returns a bool value if collides with another collider from a
        /// gameobject with layer mask 'Ground' attached;
        /// </summary>
        /// <param name="gameObjectCollider">The gameobject collider that will be a jump check</param>
        /// <returns>True if ray hits another collider | False if not hits another collider</returns>
        public static bool CheckIfIsGrounded(Collider gameObjectCollider)
        {
            float distoToGround = gameObjectCollider.bounds.extents.y;
            var groundLayerMaks = LayerMask.GetMask(_mask);
            bool hitGround = Physics.Raycast(gameObjectCollider.transform.position, Vector3.down, distoToGround + 0.1f, groundLayerMaks);

            if (hitGround)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Fires a ray from the middle of the gameobject that returns a bool value if collides with another collider from a
        /// gameobject with layer mask 'Ground' attached;
        /// </summary>
        /// <param name="gameObjectCollider">The gameobject collider that will be a jump check</param>
        /// <param name="spaceBetweenColliderAndGround">A customizable distance between gameobject collider and 'ground' collider. Default space 0.1f</param>
        /// <returns>True if ray hits another collider | False if not hits another collider</returns>
        public static bool CheckIfIsGrounded(Collider gameObjectCollider, float spaceBetweenColliderAndGround = 0.1f)
        {
            float distoToGround = gameObjectCollider.bounds.extents.y;
            var groundLayerMaks = LayerMask.GetMask(_mask);
            bool hitGround = Physics.Raycast(gameObjectCollider.transform.position, Vector3.down, distoToGround + spaceBetweenColliderAndGround, groundLayerMaks);

            if (hitGround)
            {
                return true;
            }

            return false;
        }
    }
}