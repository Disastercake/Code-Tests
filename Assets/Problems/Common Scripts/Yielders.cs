using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommonScripts
{
    /// <summary>
    /// Optimized yield commands to prevent garbage collection.
    /// </summary>
    public static class Yielders
    {
        #region Private

        // These Dictionary's allow for easily caching any possible value for yield times.

        static Dictionary<float, WaitForSeconds> _waitForSeconds = new Dictionary<float, WaitForSeconds>();
        static Dictionary<float, WaitForSecondsRealtime> _waitForSecondsRealtime = new Dictionary<float, WaitForSecondsRealtime>();

        #endregion

        #region Public

        public static WaitForEndOfFrame EndOfFrame { get; } = new WaitForEndOfFrame();
        public static WaitForFixedUpdate FixedUpdate { get; } = new WaitForFixedUpdate();

        /// <summary>
        /// This uses unscaled time.  It WILL finish waiting even if (Time.timeScale == 0f).
        /// </summary>
        public static WaitForSecondsRealtime WaitReal(float seconds)
        {
            WaitForSecondsRealtime waitClass = null;

            if (_waitForSecondsRealtime.TryGetValue(seconds, out waitClass) == false)
            {
                waitClass = new WaitForSecondsRealtime(seconds);
                _waitForSecondsRealtime.Add(seconds, waitClass);
            }

            return waitClass;
        }

        /// <summary>
        /// This uses scaled time.  It will NOT finish waiting if (Time.timeScale == 0f).
        /// </summary>
        public static WaitForSeconds WaitScaled(float seconds)
        {
            WaitForSeconds waitClass = null;

            if (_waitForSeconds.TryGetValue(seconds, out waitClass) == false)
            {
                waitClass = new WaitForSeconds(seconds);
                _waitForSeconds.Add(seconds, waitClass);
            }

            return waitClass;
        }

        #endregion
    }
}
