module Fanna.Core.LuaStack

open LuaValue

type LuaStack(size: int) =
    let __stack: System.Collections.Generic.List<LuaValue> =
        System.Collections.Generic.List(size)

    member public _.Push = __stack.Add
    member public _.Top = __stack.Count

    member public _.Pop() =
        let value = __stack[__stack.Count - 1]
        __stack.RemoveAt(__stack.Count - 1)
        value

    member public _.AbsIndex(n: int) =
        (if n < 0 then n + __stack.Count else n - 1)

    member public this.Get(n: int) =
        this.AbsIndex(n)
        |> fun valid ->
            if valid > 0 && valid <= __stack.Count + 1 then
                __stack[valid]
            else
                LUA_TNIL

    member public _.GetTop() = __stack[__stack.Count - 1]

    member public this.Set(n: int, value: LuaValue) =
        __stack.Insert(this.AbsIndex(n), value)

    /// copy a value from one location to another
    member public this.Copy(from: int, _to: int) = this.Set(_to, (this.Get(from)))

    /// Push the value at the specified index to the top of the school
    member public this.PushValue(n: int) = this.Push(this.Get(n))

    /// Pop the top value of the stack, and then write to the specified location
    member public this.Replace(n: int) = this.Set(n, this.Pop())

    /// Pop up the roof value and insert it into the specified position.
    member public this.Insert(n: int) = this.Set(n, this.Pop())

    /// delete the value at the specified index
    member public this.Remove(n: int) = __stack.RemoveAt(n)

    member public this.Reverse() = __stack.Reverse()
