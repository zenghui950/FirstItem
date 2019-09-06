#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class UnityEngineParticleSystemWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.ParticleSystem);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 39, 17);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetParticles", _m_SetParticles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetParticles", _m_GetParticles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Simulate", _m_Simulate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Play", _m_Play);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Stop", _m_Stop);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Pause", _m_Pause);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsAlive", _m_IsAlive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Emit", _m_Emit);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "startDelay", _g_get_startDelay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isPlaying", _g_get_isPlaying);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isStopped", _g_get_isStopped);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isPaused", _g_get_isPaused);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "loop", _g_get_loop);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "playOnAwake", _g_get_playOnAwake);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "time", _g_get_time);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "duration", _g_get_duration);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "playbackSpeed", _g_get_playbackSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "particleCount", _g_get_particleCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startSpeed", _g_get_startSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startSize", _g_get_startSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startColor", _g_get_startColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startRotation", _g_get_startRotation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startRotation3D", _g_get_startRotation3D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startLifetime", _g_get_startLifetime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "gravityModifier", _g_get_gravityModifier);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxParticles", _g_get_maxParticles);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "simulationSpace", _g_get_simulationSpace);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scalingMode", _g_get_scalingMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "randomSeed", _g_get_randomSeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useAutoRandomSeed", _g_get_useAutoRandomSeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "emission", _g_get_emission);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shape", _g_get_shape);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "velocityOverLifetime", _g_get_velocityOverLifetime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "limitVelocityOverLifetime", _g_get_limitVelocityOverLifetime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "inheritVelocity", _g_get_inheritVelocity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "forceOverLifetime", _g_get_forceOverLifetime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "colorOverLifetime", _g_get_colorOverLifetime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "colorBySpeed", _g_get_colorBySpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sizeOverLifetime", _g_get_sizeOverLifetime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sizeBySpeed", _g_get_sizeBySpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotationOverLifetime", _g_get_rotationOverLifetime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotationBySpeed", _g_get_rotationBySpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "externalForces", _g_get_externalForces);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "collision", _g_get_collision);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "trigger", _g_get_trigger);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "subEmitters", _g_get_subEmitters);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "textureSheetAnimation", _g_get_textureSheetAnimation);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "startDelay", _s_set_startDelay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "loop", _s_set_loop);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "playOnAwake", _s_set_playOnAwake);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "time", _s_set_time);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "playbackSpeed", _s_set_playbackSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startSpeed", _s_set_startSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startSize", _s_set_startSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startColor", _s_set_startColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startRotation", _s_set_startRotation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startRotation3D", _s_set_startRotation3D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startLifetime", _s_set_startLifetime);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "gravityModifier", _s_set_gravityModifier);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxParticles", _s_set_maxParticles);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "simulationSpace", _s_set_simulationSpace);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scalingMode", _s_set_scalingMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "randomSeed", _s_set_randomSeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useAutoRandomSeed", _s_set_useAutoRandomSeed);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.ParticleSystem gen_ret = new UnityEngine.ParticleSystem();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ParticleSystem constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetParticles(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.ParticleSystem.Particle[] _particles = (UnityEngine.ParticleSystem.Particle[])translator.GetObject(L, 2, typeof(UnityEngine.ParticleSystem.Particle[]));
                    int _size = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.SetParticles( _particles, _size );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetParticles(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.ParticleSystem.Particle[] _particles = (UnityEngine.ParticleSystem.Particle[])translator.GetObject(L, 2, typeof(UnityEngine.ParticleSystem.Particle[]));
                    
                        int gen_ret = gen_to_be_invoked.GetParticles( _particles );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Simulate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _t = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.Simulate( _t );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _t = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.Simulate( _t, _withChildren );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _t = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 3);
                    bool _restart = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.Simulate( _t, _withChildren, _restart );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    float _t = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 3);
                    bool _restart = LuaAPI.lua_toboolean(L, 4);
                    bool _fixedTimeStep = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.Simulate( _t, _withChildren, _restart, _fixedTimeStep );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ParticleSystem.Simulate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Play(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.Play(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _withChildren = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.Play( _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ParticleSystem.Play!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stop(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.Stop(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _withChildren = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.Stop( _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ParticleSystem.Stop!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pause(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.Pause(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _withChildren = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.Pause( _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ParticleSystem.Pause!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _withChildren = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.Clear( _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ParticleSystem.Clear!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAlive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        bool gen_ret = gen_to_be_invoked.IsAlive(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _withChildren = LuaAPI.lua_toboolean(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.IsAlive( _withChildren );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ParticleSystem.IsAlive!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Emit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _count = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.Emit( _count );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.ParticleSystem.EmitParams>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.ParticleSystem.EmitParams _emitParams;translator.Get(L, 2, out _emitParams);
                    int _count = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.Emit( _emitParams, _count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ParticleSystem.Emit!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startDelay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.startDelay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isPlaying(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isPlaying);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isStopped(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isStopped);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isPaused(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isPaused);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_loop(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.loop);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_playOnAwake(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.playOnAwake);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_time(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.time);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_duration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.duration);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_playbackSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.playbackSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_particleCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.particleCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.startSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.startSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.startColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.startRotation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startRotation3D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.startRotation3D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startLifetime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.startLifetime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gravityModifier(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.gravityModifier);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxParticles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.maxParticles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_simulationSpace(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.simulationSpace);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scalingMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.scalingMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_randomSeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.randomSeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useAutoRandomSeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useAutoRandomSeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_emission(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.emission);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shape(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shape);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_velocityOverLifetime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.velocityOverLifetime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_limitVelocityOverLifetime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.limitVelocityOverLifetime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_inheritVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.inheritVelocity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_forceOverLifetime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.forceOverLifetime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colorOverLifetime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.colorOverLifetime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colorBySpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.colorBySpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sizeOverLifetime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.sizeOverLifetime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sizeBySpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.sizeBySpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotationOverLifetime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rotationOverLifetime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotationBySpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rotationBySpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_externalForces(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.externalForces);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_collision(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.collision);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_trigger(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.trigger);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_subEmitters(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.subEmitters);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_textureSheetAnimation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.textureSheetAnimation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startDelay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startDelay = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_loop(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.loop = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_playOnAwake(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.playOnAwake = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_time(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.time = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_playbackSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.playbackSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startSize = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.startColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startRotation = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startRotation3D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.startRotation3D = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startLifetime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startLifetime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gravityModifier(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.gravityModifier = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxParticles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxParticles = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_simulationSpace(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                UnityEngine.ParticleSystemSimulationSpace gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.simulationSpace = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scalingMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                UnityEngine.ParticleSystemScalingMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.scalingMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_randomSeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.randomSeed = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useAutoRandomSeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ParticleSystem gen_to_be_invoked = (UnityEngine.ParticleSystem)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useAutoRandomSeed = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
