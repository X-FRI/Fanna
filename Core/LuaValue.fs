module Fanna.Core.LuaValue

/// At the language level, Lua supports a total of 8 data types,
/// namely nil, boolean, number, string, table, function, thread and user data (userdata).
/// The Lua stack can also access values ​​by index.
/// If an invalid index is provided to the Lua API, then the type of the value corresponding to this index is LUA_TNONE.
type LuaValue =
    | LUA_TNONE
    | LUA_TNIL
    | LUA_TBOOLEAN
    | LUA_TLIGHTUSERDATA
    | LUA_TNUMBER
    | LUA_TSTRING
    | LUA_TTABLE
    | LUA_TFUNCTION
    | LUA_TUSERDATA
    | LUA_TTHREAD

    override this.ToString() = 
        match this with
        | LUA_TNONE -> "LUA_TNONE"
        | LUA_TNIL -> "LUA_TNIL"
        | LUA_TBOOLEAN -> "LUA_TBOOLEAN"
        | LUA_TLIGHTUSERDATA -> "LUA_TLIGHTUSERDATA"
        | LUA_TNUMBER -> "LUA_TNUMBER"
        | LUA_TSTRING -> "LUA_TSTRING"
        | LUA_TTABLE -> "LUA_TTABLE"
        | LUA_TFUNCTION -> "LUA_TFUNCTION"
        | LUA_TUSERDATA -> "LUA_TUSERDATA"
        | LUA_TTHREAD -> "LUA_TTHREAD"