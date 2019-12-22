
#  用户交互 ：
    使用Editor类的GetXXX函数获取用户输入的时候 ，需要传入
    PromptXXXOptions 参数来设置提示的参数，这里的 XXX 是代指特定的对象，如
    GetString
    GetDistance
    GetAngle
    GetPoint

    GetKeywords 
    GetCorner
    通过这些交互函数获取的用户输入结果保存在 PromptResult 或者其派生类对象中，
    如 PromptDoubleResult,、PromptIntegerResult
    

#  PromptStatus 的值
    PromptStatus 的值 表示的意义
    
    OK 用户输入值有效，正常输入
    Cancel 用户按下了 Esc 键，取消输入
    Error 调用失败
    Modeless 用户从属性面板输入
    None 用户输入回车
    Keyword 输入关键字
    Other 其他输入结果

    
#  PromptXXXOptions 类的限定属性
    属性值 说明
    AllowNone 是否允许空输入
    AllowZero 是否允许输入 0
    AllowNegative 是否允许输入负数
    AllowArbitraryInput 是否允许任意输入(无论什么类型)
     
    不同的 PromptXXXOptions 类可能具有不同的 AllowYYY 属性，在使用时候
    需要根据实际的实际情况来设置。