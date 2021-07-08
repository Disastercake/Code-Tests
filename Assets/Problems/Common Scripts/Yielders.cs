/*===============================
Copyright 2013, Disastercake (https://www.disastercake.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
===============================*/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Optimized yield commands to prevent garbage collection.
/// </summary>
public static class Wait
{
    #region Private

    // These Dictionary's allow for easily caching any possible value for yield times to avoid re-allocating them.

    static Dictionary<float, WaitForSeconds> _waitForSeconds = new Dictionary<float, WaitForSeconds>();
    static Dictionary<float, WaitForSecondsRealtime> _waitForSecondsRealtime = new Dictionary<float, WaitForSecondsRealtime>();

    #endregion

    #region Public

    public static WaitForEndOfFrame ForEndOfFrame { get; } = new WaitForEndOfFrame();
    public static WaitForFixedUpdate ForFixedUpdate { get; } = new WaitForFixedUpdate();

    /// <summary>
    /// This uses unscaled time.  It WILL finish waiting even if (Time.timeScale == 0f).
    /// </summary>
    public static WaitForSecondsRealtime ForSecondsRealtime(float seconds)
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
    public static WaitForSeconds ForSeconds(float seconds)
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
