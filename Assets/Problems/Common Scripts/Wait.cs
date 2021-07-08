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
    // These Dictionary's allow for easily caching any possible value for yield times to avoid re-allocating them.
    private static Dictionary<float, WaitForSeconds> _waitForSeconds = new Dictionary<float, WaitForSeconds>();
    private static Dictionary<float, WaitForSecondsRealtime> _waitForSecondsRealtime = new Dictionary<float, WaitForSecondsRealtime>();

    /// <summary>
    /// Waits until the end of the frame after Unity has rendered every Camera and GUI, just before displaying the frame on screen.
    /// </summary>
    public static WaitForEndOfFrame ForEndOfFrame { get; } = new WaitForEndOfFrame();

    /// <summary>
    /// Waits until next fixed frame rate update function. See also: MonoBehaviour.FixedUpdate
    /// </summary>
    public static WaitForFixedUpdate ForFixedUpdate { get; } = new WaitForFixedUpdate();

    /// <summary>
    /// Suspends the coroutine execution for the given amount of seconds using unscaled time.
    /// Note: The coroutine will proceed even if (Time.timeScale == 0).
    /// </summary>
    public static WaitForSecondsRealtime ForSecondsRealtime(float seconds)
    {
        WaitForSecondsRealtime w = null;

        if (_waitForSecondsRealtime.TryGetValue(seconds, out w) == false)
        {
            w = new WaitForSecondsRealtime(seconds);
            _waitForSecondsRealtime.Add(seconds, w);
        }

        return w;
    }

    /// <summary>
    /// Suspends the coroutine execution for the given amount of seconds using scaled time.
    /// Note: If (Time.timeScale == 0), then the coroutine will NOT proceed until (Time.timeScale > 0).
    /// </summary>
    public static WaitForSeconds ForSeconds(float seconds)
    {
        WaitForSeconds w = null;

        if (_waitForSeconds.TryGetValue(seconds, out w) == false)
        {
            w = new WaitForSeconds(seconds);
            _waitForSeconds.Add(seconds, w);
        }

        return w;
    }
}
