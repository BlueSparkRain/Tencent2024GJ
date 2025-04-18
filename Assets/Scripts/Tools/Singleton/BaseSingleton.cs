/// <summary>
/// 单例模式基类 主要目的是避免代码的冗余 方便我们实现单例模式的类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseSingletonManager<T> where T : class, new()
{
    private static T instance;
    //用于加锁的对象
    protected static readonly object lockObj = new object();

    //属性的方式
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }
            }
            return instance;
        }
    }
}
