using UnityEngine;

public class JoystickUtil
{
    // 조이스틱 위치와 크기가 바뀌면 이 필드를 수정해주세요
    private float _f_initx = 540f;
    private float _f_inity = 440f;
    private float _f_initz = 0f;
    private float _f_maxdist = 150f;

    private float _f_x;
    private float _f_y;
    private float _f_z = 0f;

    // TODO: 명명 규칙 위반을 수정해야할까요 아니면 자체 매뉴얼대로 가야할까요
    public float f_x
    {
        get => _f_x;
        set => _f_x = value;
    }

    public float f_y
    {
        get => _f_y;
        set => _f_y = value;
    }

    public float f_z
    {
        get => _f_z;
        set => _f_z = value;
    }

    public JoystickUtil()
    {
        this.f_x = _f_initx;
        this.f_y = _f_inity;
        this.f_z = _f_initz;
    }

    /// <summary>
    /// 마우스가 범위를 벗어나도 조이스틱이 일정 거리를 유지하게 합니다
    /// </summary>
    /// <param name="init"></param>
    /// <param name="curr"></param>
    public void LimitPosition(Vector2 init, Vector2 curr)
    {
        float x1 = init.x - _f_initx;
        float x2 = curr.x - _f_initx;
        float y1 = init.y - _f_inity;
        float y2 = curr.y - _f_inity;

        float distance = Mathf.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        
        if (distance > _f_maxdist)
        {
            x2 *= (_f_maxdist / distance);
            y2 *= (_f_maxdist / distance);
        }
        
        this.f_x = x2 + _f_initx;
        this.f_y = y2 + _f_inity;
    }

    /// <summary>
    /// 조이스틱 위치를 되돌려 놓습니다
    /// </summary>
    public void ResetPosition()
    {
        this.f_x = _f_initx;
        this.f_y = _f_inity;
    }
}
