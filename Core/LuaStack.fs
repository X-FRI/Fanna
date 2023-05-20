module Fanna.Core.LuaStack

open LuaValue

type LuaStack(size: int) =
    let __stack: System.Collections.Generic.List<LuaValue> =
        System.Collections.Generic.List(size)

    member public _.Push = __stack.Add
    member public _.Length = __stack.Count

    member public _.Pop() =
        let value = __stack[__stack.Count - 1]
        __stack.RemoveAt(__stack.Count - 1)
        value

    member public _.Get(n: int) =
        (if n < 0 then n + __stack.Count else n - 1)
        |> fun valid ->
            if valid > 0 && valid <= __stack.Count + 1 then
                __stack[valid]
            else
                LUA_TNIL

    member public _.Set(n: int, value: LuaValue) =
        __stack.Insert((if n < 0 then n + __stack.Count + 1 else n - 1), value)
