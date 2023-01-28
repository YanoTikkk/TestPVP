using System.Reflection;
using _App;
using UnityEngine;

namespace _Config
{
    [CreateAssetMenu(fileName = "CoreConfig", menuName = "Configurations/CoreConfig")]
    public class CoreConfig : ScriptableObject, ICoreConfig, IAppInitialize
    {
        [Header("Core Config Fields")]
        [SerializeField] private MainConfig _mainConfig;
        
        public IMainConfig Main => _mainConfig;

        public void OnInitialize(float time)
        {
            var fieldsInfo = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldInfo in fieldsInfo)
            {
                var value = fieldInfo.GetValue(this);

                if (value is IAppInitialize target)
                    target.OnInitialize(time);
            }
        }
    }
}