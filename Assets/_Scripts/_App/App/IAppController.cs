namespace _App
{
    public interface IAppInitialize
    {
        void OnInitialize(float time);
    }

    public interface IAppUpdate
    {
        void OnUpdate(float time, float deltaTime);
    }

    public interface IAppLateUpdate
    {
        void OnLateUpdate(float time, float deltaTime);
    }

    public interface IAppFixedUpdate
    {
        void OnFixedUpdate(float time, float fixedDeltaTime);
    }

    public interface IAppDestroy
    {
        void OnDestroy(float time);
    }
}