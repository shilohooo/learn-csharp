using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Data;
using Avalonia.Input;

namespace Avalonia.CustomControls.RatingControlSample.Controls;

/// <summary>
///     自定义的评分控件
/// </summary>
[TemplatePart("PART_StarsPresenter", typeof(ItemsControl))]
public class RatingControl : TemplatedControl
{
    #region Private Fields

    /// <summary>
    ///     该字段指向控件模板中的 PART_StarsPresenter 部分，存储了评分的星星列表
    /// </summary>
    private ItemsControl? _starsPresenter;

    #endregion

    #region Constructors

    public RatingControl()
    {
        UpdateStars();
    }

    #endregion

    #region Protected Methods

    /// <summary>
    ///     更新数据校验状态
    /// </summary>
    /// <param name="property">属性</param>
    /// <param name="state">数据校验状态</param>
    /// <param name="error">数据校验异常</param>
    protected override void UpdateDataValidation(AvaloniaProperty property, BindingValueType state, Exception? error)
    {
        base.UpdateDataValidation(property, state, error);
        if (property == ValueProperty) DataValidationErrors.SetError(this, error);
    }

    /// <inheritdoc />
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == NumberOfStarsProperty) UpdateStars();
    }

    /// <inheritdoc />
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        // 这个方法会在控件显示到界面之前调用
        base.OnApplyTemplate(e);

        if (_starsPresenter is not null) _starsPresenter.PointerReleased -= StarsPresenter_PointerReleased;

        _starsPresenter = e.NameScope.Find("PART_StarsPresenter") as ItemsControl;

        if (_starsPresenter is not null) _starsPresenter.PointerReleased += StarsPresenter_PointerReleased;
    }

    /// <summary>
    ///     星星列表点击事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StarsPresenter_PointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        // 选了多少个星星，设置到 Value 属性中
        if (e.Source is Path star) Value = star.DataContext as int? ?? 0;
    }

    #endregion

    #region Private Methods

    /// <summary>
    ///     限制 <see cref="NumberOfStars" /> 属性的值最小为 1
    /// </summary>
    /// <param name="instance">调用此方法的控件实例</param>
    /// <param name="value">需要限制的值</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private static int CoerceNumberOfStars(AvaloniaObject instance, int value)
    {
        return Math.Max(1, value);
    }

    /// <summary>
    ///     根据设置的数量更新星星列表
    /// </summary>
    private void UpdateStars()
    {
        Stars = Enumerable.Range(1, NumberOfStars);
    }

    #endregion

    #region Styled Properties

    /// <summary>
    ///     定义 <see cref="NumberOfStars" /> 的样式属性
    /// </summary>
    public static readonly StyledProperty<int> NumberOfStarsProperty = AvaloniaProperty.Register<RatingControl, int>(
        nameof(NumberOfStars),
        // 属性默认值
        5,
        // 提供一个备用的有效值，防止设置的属性值超出范围，比如设置为负数
        coerce: CoerceNumberOfStars
    );

    /// <summary>
    ///     星星的数量，可以由开发者设置，可以通过样式进行修改（Style + Setter）
    /// </summary>
    public int NumberOfStars
    {
        get => GetValue(NumberOfStarsProperty);
        set => SetValue(NumberOfStarsProperty, value);
    }

    #endregion

    #region Direct Properties

    /// <summary>
    ///     定义 <see cref="Value" /> 属性
    /// </summary>
    public static readonly DirectProperty<RatingControl, int> ValueProperty =
        AvaloniaProperty.RegisterDirect<RatingControl, int>(
            // 属性名称
            nameof(Value),
            // getter
            o => o.Value,
            // setter
            (o, v) => o.Value = v,
            // 绑定方式
            defaultBindingMode: BindingMode.TwoWay,
            // 开启数据校验
            enableDataValidation: true
        );

    /// <summary>
    ///     backing field of  <see cref="Value" />
    /// </summary>
    private int _value;


    /// <summary>
    ///     评分值，用户与控件交互时设置，用户点击星星图标，该值就会发送改变
    /// </summary>
    public int Value
    {
        get => _value;
        set => SetAndRaise(ValueProperty, ref _value, value);
    }

    /// <summary>
    ///     定义 <see cref="Stars" /> 属性
    /// </summary>
    public static readonly DirectProperty<RatingControl, IEnumerable<int>> StarsProperty =
        AvaloniaProperty.RegisterDirect<RatingControl, IEnumerable<int>>(
            nameof(Stars),
            o => o.Stars
        );

    /// <summary>
    ///     backing field of <see cref="Stars" />
    /// </summary>
    private IEnumerable<int> _stars = Enumerable.Range(1, 5);

    /// <summary>
    ///     星星列表，ItemsControl 控件的数据源
    ///     <remarks>这里有多少条数据，ItemsControl 里面就会显示多少个星星图标</remarks>
    /// </summary>
    public IEnumerable<int> Stars
    {
        get => _stars;
        private set => SetAndRaise(StarsProperty, ref _stars, value);
    }

    #endregion
}