using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ios系统的优化做的好,并且分辨率方案不多,测试起来容易,无需更改分辨率
//android平台可以适当缩小一下分辨率,以便提高渲染效率
public struct ScreenSize
{
    public int width;
    public int height;
}

public class ScreenConfig
{
    private static int manualHeight = 0;

    public static void init()
    {

        float expect_width = 1080f;
        float expect_height = 720f;
        float aspectExpect = expect_width / expect_height;
        float aspectDevice = (float)Screen.width / (float)Screen.height;
        if(aspectDevice < aspectExpect )//越小,看起来越方,此时应该以宽度为基础,上下黑边
        {
            manualHeight = Mathf.FloorToInt( expect_width / (float)Screen.width * Screen.height);
        }
        else //越大则月越扁,应以高度为基础左右黑边;
        {
            manualHeight = Mathf.FloorToInt(expect_height);
        }
    }
    /*
     当摄像机orthographicSize属性值等于当前屏幕高度单位的一半时，摄像机大小正好与屏幕大小相等。
     注意这里提到的是屏幕单位高度的一半，这个数值是经过像素到单位比即Pixels To Units换算的，Unity2D中这个比例的默认值是100，即100像素等于1单位。
     如果我们的游戏屏幕有640像素高，那么实际换算成单位高度则是6.4个单位，当我们摄像机的orthographicSize值是3.2时，摄像机大小刚好与屏幕大小相等。
     */
    public static int ManualHeight
    {
        get { return manualHeight; }
    }
}
