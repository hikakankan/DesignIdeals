namespace ABCEditorFSharp

type GUIEventObject(et, ev) =
    let mutable event_type_val = et
    let mutable event_value_val = ev
    member this.EventType
        with get() = event_type_val
    member this.EventValue
        with get() = event_value_val

type GUIObject(set_text : string -> unit) =
    let set_text_proc : string -> unit = set_text 
    let mutable event_val = null
    let mutable textbox_val = null
    member this.Event
        with get() = event_val
        and set(v) = event_val <- v
    member this.gui_enter() = event_val
    member this.gui_return(v) = do set_text_proc v

type UserObjects() =
    let mutable current_string_val = ""
    member this.current_string
        with get() = current_string_val
        and set(v) = current_string_val <- v

type ABCEditor(set_text : string -> unit, close : unit -> unit) =
    let close_proc = close
    let gui_object = new GUIObject(set_text)
    let user_objects = new UserObjects()
    member this.ButtonA_Click_Proc() =
        let str = user_objects.get_current_string();
        user_objects.set_current_string(str + "A");
        gui_object.gui_return(user_objects.get_current_string());
    member this.ButtonB_Click_Proc() =
        let str = user_objects.get_current_string();
        user_objects.set_current_string(str + "B");
        gui_object.gui_return(user_objects.get_current_string());
    member this.ButtonC_Click_Proc() =
        let str = user_objects.get_current_string();
        user_objects.set_current_string(str + "C");
        gui_object.gui_return(user_objects.get_current_string());
    member this.ButtonExit_Click_Proc() =
        do close_proc()

type ABCEditor1(set_text : string -> unit, close : int -> unit) =
    let close_proc = close
    let gui_object = new GUIObject(set_text)
    let user_objects = new UserObjects()
    member this.ButtonA_Click_Proc() =
        let str = user_objects.get_current_string();
        user_objects.set_current_string(str + "A");
        gui_object.gui_return(user_objects.get_current_string());
    member this.ButtonB_Click_Proc() =
        let str = user_objects.get_current_string();
        user_objects.set_current_string(str + "B");
        gui_object.gui_return(user_objects.get_current_string());
    member this.ButtonC_Click_Proc() =
        let str = user_objects.get_current_string();
        user_objects.set_current_string(str + "C");
        gui_object.gui_return(user_objects.get_current_string());
    member this.ButtonExit_Click_Proc() =
        do close_proc(0)
