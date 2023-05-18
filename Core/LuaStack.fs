module Fanna.Core.LuaStack

open LuaValue

type LuaStack() =
    member public _.Slots: System.Collections.Generic.List<LuaValue> =
        System.Collections.Generic.List()

    member public _.Top = 0

    member public this.Length() = this.Slots.Count

    member public this.Push(value: LuaValue) = this.Slots.Add(value) |> ignore

    member public this.Pop() =
        let value = this.Slots[this.Slots.Count - 1]
        this.Slots.RemoveAt(this.Slots.Count - 1)
        value

    member private this.AbsIndex(n: int) =
        if n >= 0 then n else n + this.Slots.Count + 1

    member public this.Get(n: int) =
        let absIndex = this.AbsIndex(n)

        if absIndex < 0 && absIndex > this.Slots.Count then
            LUA_TNIL
        else
            this.Slots[absIndex]

    member public this.Set(n: int, value: LuaValue) = this.Slots.Insert(n, value)
