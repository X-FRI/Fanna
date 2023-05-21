/// Lua State encapsulates the entire Lua interpreter state
module Fanna.Core.LuaState

open LuaStack
open LuaValue

type LuaState() =
    // Temporarily set the initial capacity of LuaStack to 20, and it will be adjusted later
    inherit LuaStack(20)

    member public this.Type(idx: int) = ()
    member public this.IsNone(idx: int) = ()
    member public this.IsNil(idx: int) = ()
    member public this.IsNoneOrNil(idx: int) = ()
    member public this.IsBoolean(idx: int) = ()
    member public this.IsInteger(idx: int) = ()
    member public this.IsNumber(idx: int) = ()
    member public this.IsString(idx: int) = ()
    member public this.ToBoolean(idx: int) = ()
    member public this.ToInteger(idx: int) = ()
    member public this.ToIntegerX(idx: int) = ()
    member public this.ToNumber(idx: int) = ()
    member public this.ToNumberX(idx: int) = ()
    member public this.ToString(idx: int) = ()
    member public this.ToStringX(idx: int) = ()