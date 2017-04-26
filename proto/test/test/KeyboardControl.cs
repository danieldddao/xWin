// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: keyboard_control.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from keyboard_control.proto</summary>
public static partial class KeyboardControlReflection {

  #region Descriptor
  /// <summary>File descriptor for keyboard_control.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static KeyboardControlReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChZrZXlib2FyZF9jb250cm9sLnByb3RvGhNtb3VzZV9jb250cm9sLnByb3Rv",
          "ItgGCg1UeXBpbmdDb250cm9sEg0KBXRpZXIxGAEgAygFEg0KBXRpZXIyGAIg",
          "AygFEi4KCGJpbmRpbmdzGAMgAygLMhwuVHlwaW5nQ29udHJvbC5CaW5kaW5n",
          "c0VudHJ5EhoKBGJhc2UYBCABKAsyDC5LZXlib2FyZFNldBI7Cg9rZXlib2Fy",
          "ZF9zZWxlY3QYBSADKAsyIi5UeXBpbmdDb250cm9sLktleWJvYXJkU2VsZWN0",
          "RW50cnkSGgoKbGVmdF9zdGljaxgGIAEoCzIGLlN0aWNrEhsKC3JpZ2h0X3N0",
          "aWNrGAcgASgLMgYuU3RpY2sSHgoMbGVmdF90cmlnZ2VyGAggASgLMgguVHJp",
          "Z2dlchIfCg1yaWdodF90cmlnZ2VyGAkgASgLMgguVHJpZ2dlchIMCgRuYW1l",
          "GAogASgJEhMKC2Rlc2NyaXB0aW9uGAsgASgJGnkKF0tleWJvYXJkQWN0aW9u",
          "Q29udGFpbmVyEi4KB2JpbmRpbmcYASABKA4yHS5UeXBpbmdDb250cm9sLktl",
          "eWJvYXJkQWN0aW9uEi4KC3doZW5fYWN0aXZlGAIgASgOMhkuVHlwaW5nQ29u",
          "dHJvbC5BY3RpdmVXaGVuGlcKDUJpbmRpbmdzRW50cnkSCwoDa2V5GAEgASgF",
          "EjUKBXZhbHVlGAIgASgLMiYuVHlwaW5nQ29udHJvbC5LZXlib2FyZEFjdGlv",
          "bkNvbnRhaW5lcjoCOAEaQwoTS2V5Ym9hcmRTZWxlY3RFbnRyeRILCgNrZXkY",
          "ASABKAUSGwoFdmFsdWUYAiABKAsyDC5LZXlib2FyZFNldDoCOAEiqgEKDktl",
          "eWJvYXJkQWN0aW9uEgsKB0NvbmZpcm0QABIPCgtMZWF2ZVR5cGluZxABEgwK",
          "CE9wZW5NZW51EAISDgoKQ3Vyc29yTGVmdBADEg8KC0N1cnNvclJpZ2h0EAQS",
          "DAoIQ3Vyc29yVXAQBRIOCgpDdXJzb3JEb3duEAYSCgoGVUlMZWZ0EAcSCwoH",
          "VUlSaWdodBAIEggKBFVJVXAQCRIKCgZVSURvd24QCiI9CgpBY3RpdmVXaGVu",
          "EgsKB1ByZXNzZWQQABIICgRIZWxkEAESDAoIUmVsZWFzZWQQAhIKCgZTdGF5",
          "ZWQQAyKHAQoLS2V5Ym9hcmRTZXQSDQoFY291bnQYASABKAUSEAoIc3ViY291",
          "bnQYAiABKAUSJgoDc2V0GAMgAygLMhkuS2V5Ym9hcmRTZXQuU3RyaW5nQ2hv",
          "aWNlGi8KDFN0cmluZ0Nob2ljZRIPCgdkaXNwbGF5GAEgASgJEg4KBnN1YnNl",
          "dBgCIAMoCWIGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { global::MouseControlReflection.Descriptor, },
        new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::TypingControl), global::TypingControl.Parser, new[]{ "Tier1", "Tier2", "Bindings", "Base", "KeyboardSelect", "LeftStick", "RightStick", "LeftTrigger", "RightTrigger", "Name", "Description" }, null, new[]{ typeof(global::TypingControl.Types.KeyboardAction), typeof(global::TypingControl.Types.ActiveWhen) }, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::TypingControl.Types.KeyboardActionContainer), global::TypingControl.Types.KeyboardActionContainer.Parser, new[]{ "Binding", "WhenActive" }, null, null, null),
          null, null, }),
          new pbr::GeneratedClrTypeInfo(typeof(global::KeyboardSet), global::KeyboardSet.Parser, new[]{ "Count", "Subcount", "Set" }, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::KeyboardSet.Types.StringChoice), global::KeyboardSet.Types.StringChoice.Parser, new[]{ "Display", "Subset" }, null, null, null)})
        }));
  }
  #endregion

}
#region Messages
public sealed partial class TypingControl : pb::IMessage<TypingControl> {
  private static readonly pb::MessageParser<TypingControl> _parser = new pb::MessageParser<TypingControl>(() => new TypingControl());
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<TypingControl> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::KeyboardControlReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public TypingControl() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public TypingControl(TypingControl other) : this() {
    tier1_ = other.tier1_.Clone();
    tier2_ = other.tier2_.Clone();
    bindings_ = other.bindings_.Clone();
    Base = other.base_ != null ? other.Base.Clone() : null;
    keyboardSelect_ = other.keyboardSelect_.Clone();
    LeftStick = other.leftStick_ != null ? other.LeftStick.Clone() : null;
    RightStick = other.rightStick_ != null ? other.RightStick.Clone() : null;
    LeftTrigger = other.leftTrigger_ != null ? other.LeftTrigger.Clone() : null;
    RightTrigger = other.rightTrigger_ != null ? other.RightTrigger.Clone() : null;
    name_ = other.name_;
    description_ = other.description_;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public TypingControl Clone() {
    return new TypingControl(this);
  }

  /// <summary>Field number for the "tier1" field.</summary>
  public const int Tier1FieldNumber = 1;
  private static readonly pb::FieldCodec<int> _repeated_tier1_codec
      = pb::FieldCodec.ForInt32(10);
  private readonly pbc::RepeatedField<int> tier1_ = new pbc::RepeatedField<int>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<int> Tier1 {
    get { return tier1_; }
  }

  /// <summary>Field number for the "tier2" field.</summary>
  public const int Tier2FieldNumber = 2;
  private static readonly pb::FieldCodec<int> _repeated_tier2_codec
      = pb::FieldCodec.ForInt32(18);
  private readonly pbc::RepeatedField<int> tier2_ = new pbc::RepeatedField<int>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<int> Tier2 {
    get { return tier2_; }
  }

  /// <summary>Field number for the "bindings" field.</summary>
  public const int BindingsFieldNumber = 3;
  private static readonly pbc::MapField<int, global::TypingControl.Types.KeyboardActionContainer>.Codec _map_bindings_codec
      = new pbc::MapField<int, global::TypingControl.Types.KeyboardActionContainer>.Codec(pb::FieldCodec.ForInt32(8), pb::FieldCodec.ForMessage(18, global::TypingControl.Types.KeyboardActionContainer.Parser), 26);
  private readonly pbc::MapField<int, global::TypingControl.Types.KeyboardActionContainer> bindings_ = new pbc::MapField<int, global::TypingControl.Types.KeyboardActionContainer>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::MapField<int, global::TypingControl.Types.KeyboardActionContainer> Bindings {
    get { return bindings_; }
  }

  /// <summary>Field number for the "base" field.</summary>
  public const int BaseFieldNumber = 4;
  private global::KeyboardSet base_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::KeyboardSet Base {
    get { return base_; }
    set {
      base_ = value;
    }
  }

  /// <summary>Field number for the "keyboard_select" field.</summary>
  public const int KeyboardSelectFieldNumber = 5;
  private static readonly pbc::MapField<int, global::KeyboardSet>.Codec _map_keyboardSelect_codec
      = new pbc::MapField<int, global::KeyboardSet>.Codec(pb::FieldCodec.ForInt32(8), pb::FieldCodec.ForMessage(18, global::KeyboardSet.Parser), 42);
  private readonly pbc::MapField<int, global::KeyboardSet> keyboardSelect_ = new pbc::MapField<int, global::KeyboardSet>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::MapField<int, global::KeyboardSet> KeyboardSelect {
    get { return keyboardSelect_; }
  }

  /// <summary>Field number for the "left_stick" field.</summary>
  public const int LeftStickFieldNumber = 6;
  private global::Stick leftStick_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::Stick LeftStick {
    get { return leftStick_; }
    set {
      leftStick_ = value;
    }
  }

  /// <summary>Field number for the "right_stick" field.</summary>
  public const int RightStickFieldNumber = 7;
  private global::Stick rightStick_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::Stick RightStick {
    get { return rightStick_; }
    set {
      rightStick_ = value;
    }
  }

  /// <summary>Field number for the "left_trigger" field.</summary>
  public const int LeftTriggerFieldNumber = 8;
  private global::Trigger leftTrigger_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::Trigger LeftTrigger {
    get { return leftTrigger_; }
    set {
      leftTrigger_ = value;
    }
  }

  /// <summary>Field number for the "right_trigger" field.</summary>
  public const int RightTriggerFieldNumber = 9;
  private global::Trigger rightTrigger_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::Trigger RightTrigger {
    get { return rightTrigger_; }
    set {
      rightTrigger_ = value;
    }
  }

  /// <summary>Field number for the "name" field.</summary>
  public const int NameFieldNumber = 10;
  private string name_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Name {
    get { return name_; }
    set {
      name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "description" field.</summary>
  public const int DescriptionFieldNumber = 11;
  private string description_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Description {
    get { return description_; }
    set {
      description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as TypingControl);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(TypingControl other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if(!tier1_.Equals(other.tier1_)) return false;
    if(!tier2_.Equals(other.tier2_)) return false;
    if (!Bindings.Equals(other.Bindings)) return false;
    if (!object.Equals(Base, other.Base)) return false;
    if (!KeyboardSelect.Equals(other.KeyboardSelect)) return false;
    if (!object.Equals(LeftStick, other.LeftStick)) return false;
    if (!object.Equals(RightStick, other.RightStick)) return false;
    if (!object.Equals(LeftTrigger, other.LeftTrigger)) return false;
    if (!object.Equals(RightTrigger, other.RightTrigger)) return false;
    if (Name != other.Name) return false;
    if (Description != other.Description) return false;
    return true;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    hash ^= tier1_.GetHashCode();
    hash ^= tier2_.GetHashCode();
    hash ^= Bindings.GetHashCode();
    if (base_ != null) hash ^= Base.GetHashCode();
    hash ^= KeyboardSelect.GetHashCode();
    if (leftStick_ != null) hash ^= LeftStick.GetHashCode();
    if (rightStick_ != null) hash ^= RightStick.GetHashCode();
    if (leftTrigger_ != null) hash ^= LeftTrigger.GetHashCode();
    if (rightTrigger_ != null) hash ^= RightTrigger.GetHashCode();
    if (Name.Length != 0) hash ^= Name.GetHashCode();
    if (Description.Length != 0) hash ^= Description.GetHashCode();
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    tier1_.WriteTo(output, _repeated_tier1_codec);
    tier2_.WriteTo(output, _repeated_tier2_codec);
    bindings_.WriteTo(output, _map_bindings_codec);
    if (base_ != null) {
      output.WriteRawTag(34);
      output.WriteMessage(Base);
    }
    keyboardSelect_.WriteTo(output, _map_keyboardSelect_codec);
    if (leftStick_ != null) {
      output.WriteRawTag(50);
      output.WriteMessage(LeftStick);
    }
    if (rightStick_ != null) {
      output.WriteRawTag(58);
      output.WriteMessage(RightStick);
    }
    if (leftTrigger_ != null) {
      output.WriteRawTag(66);
      output.WriteMessage(LeftTrigger);
    }
    if (rightTrigger_ != null) {
      output.WriteRawTag(74);
      output.WriteMessage(RightTrigger);
    }
    if (Name.Length != 0) {
      output.WriteRawTag(82);
      output.WriteString(Name);
    }
    if (Description.Length != 0) {
      output.WriteRawTag(90);
      output.WriteString(Description);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    size += tier1_.CalculateSize(_repeated_tier1_codec);
    size += tier2_.CalculateSize(_repeated_tier2_codec);
    size += bindings_.CalculateSize(_map_bindings_codec);
    if (base_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(Base);
    }
    size += keyboardSelect_.CalculateSize(_map_keyboardSelect_codec);
    if (leftStick_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(LeftStick);
    }
    if (rightStick_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(RightStick);
    }
    if (leftTrigger_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(LeftTrigger);
    }
    if (rightTrigger_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(RightTrigger);
    }
    if (Name.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
    }
    if (Description.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(TypingControl other) {
    if (other == null) {
      return;
    }
    tier1_.Add(other.tier1_);
    tier2_.Add(other.tier2_);
    bindings_.Add(other.bindings_);
    if (other.base_ != null) {
      if (base_ == null) {
        base_ = new global::KeyboardSet();
      }
      Base.MergeFrom(other.Base);
    }
    keyboardSelect_.Add(other.keyboardSelect_);
    if (other.leftStick_ != null) {
      if (leftStick_ == null) {
        leftStick_ = new global::Stick();
      }
      LeftStick.MergeFrom(other.LeftStick);
    }
    if (other.rightStick_ != null) {
      if (rightStick_ == null) {
        rightStick_ = new global::Stick();
      }
      RightStick.MergeFrom(other.RightStick);
    }
    if (other.leftTrigger_ != null) {
      if (leftTrigger_ == null) {
        leftTrigger_ = new global::Trigger();
      }
      LeftTrigger.MergeFrom(other.LeftTrigger);
    }
    if (other.rightTrigger_ != null) {
      if (rightTrigger_ == null) {
        rightTrigger_ = new global::Trigger();
      }
      RightTrigger.MergeFrom(other.RightTrigger);
    }
    if (other.Name.Length != 0) {
      Name = other.Name;
    }
    if (other.Description.Length != 0) {
      Description = other.Description;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          input.SkipLastField();
          break;
        case 10:
        case 8: {
          tier1_.AddEntriesFrom(input, _repeated_tier1_codec);
          break;
        }
        case 18:
        case 16: {
          tier2_.AddEntriesFrom(input, _repeated_tier2_codec);
          break;
        }
        case 26: {
          bindings_.AddEntriesFrom(input, _map_bindings_codec);
          break;
        }
        case 34: {
          if (base_ == null) {
            base_ = new global::KeyboardSet();
          }
          input.ReadMessage(base_);
          break;
        }
        case 42: {
          keyboardSelect_.AddEntriesFrom(input, _map_keyboardSelect_codec);
          break;
        }
        case 50: {
          if (leftStick_ == null) {
            leftStick_ = new global::Stick();
          }
          input.ReadMessage(leftStick_);
          break;
        }
        case 58: {
          if (rightStick_ == null) {
            rightStick_ = new global::Stick();
          }
          input.ReadMessage(rightStick_);
          break;
        }
        case 66: {
          if (leftTrigger_ == null) {
            leftTrigger_ = new global::Trigger();
          }
          input.ReadMessage(leftTrigger_);
          break;
        }
        case 74: {
          if (rightTrigger_ == null) {
            rightTrigger_ = new global::Trigger();
          }
          input.ReadMessage(rightTrigger_);
          break;
        }
        case 82: {
          Name = input.ReadString();
          break;
        }
        case 90: {
          Description = input.ReadString();
          break;
        }
      }
    }
  }

  #region Nested types
  /// <summary>Container for nested types declared in the TypingControl message type.</summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static partial class Types {
    public enum KeyboardAction {
      [pbr::OriginalName("Confirm")] Confirm = 0,
      [pbr::OriginalName("LeaveTyping")] LeaveTyping = 1,
      [pbr::OriginalName("OpenMenu")] OpenMenu = 2,
      [pbr::OriginalName("CursorLeft")] CursorLeft = 3,
      [pbr::OriginalName("CursorRight")] CursorRight = 4,
      [pbr::OriginalName("CursorUp")] CursorUp = 5,
      [pbr::OriginalName("CursorDown")] CursorDown = 6,
      [pbr::OriginalName("UILeft")] Uileft = 7,
      [pbr::OriginalName("UIRight")] Uiright = 8,
      [pbr::OriginalName("UIUp")] Uiup = 9,
      [pbr::OriginalName("UIDown")] Uidown = 10,
    }

    public enum ActiveWhen {
      [pbr::OriginalName("Pressed")] Pressed = 0,
      [pbr::OriginalName("Held")] Held = 1,
      [pbr::OriginalName("Released")] Released = 2,
      [pbr::OriginalName("Stayed")] Stayed = 3,
    }

    public sealed partial class KeyboardActionContainer : pb::IMessage<KeyboardActionContainer> {
      private static readonly pb::MessageParser<KeyboardActionContainer> _parser = new pb::MessageParser<KeyboardActionContainer>(() => new KeyboardActionContainer());
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public static pb::MessageParser<KeyboardActionContainer> Parser { get { return _parser; } }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public static pbr::MessageDescriptor Descriptor {
        get { return global::TypingControl.Descriptor.NestedTypes[0]; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      pbr::MessageDescriptor pb::IMessage.Descriptor {
        get { return Descriptor; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public KeyboardActionContainer() {
        OnConstruction();
      }

      partial void OnConstruction();

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public KeyboardActionContainer(KeyboardActionContainer other) : this() {
        binding_ = other.binding_;
        whenActive_ = other.whenActive_;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public KeyboardActionContainer Clone() {
        return new KeyboardActionContainer(this);
      }

      /// <summary>Field number for the "binding" field.</summary>
      public const int BindingFieldNumber = 1;
      private global::TypingControl.Types.KeyboardAction binding_ = 0;
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public global::TypingControl.Types.KeyboardAction Binding {
        get { return binding_; }
        set {
          binding_ = value;
        }
      }

      /// <summary>Field number for the "when_active" field.</summary>
      public const int WhenActiveFieldNumber = 2;
      private global::TypingControl.Types.ActiveWhen whenActive_ = 0;
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public global::TypingControl.Types.ActiveWhen WhenActive {
        get { return whenActive_; }
        set {
          whenActive_ = value;
        }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override bool Equals(object other) {
        return Equals(other as KeyboardActionContainer);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public bool Equals(KeyboardActionContainer other) {
        if (ReferenceEquals(other, null)) {
          return false;
        }
        if (ReferenceEquals(other, this)) {
          return true;
        }
        if (Binding != other.Binding) return false;
        if (WhenActive != other.WhenActive) return false;
        return true;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override int GetHashCode() {
        int hash = 1;
        if (Binding != 0) hash ^= Binding.GetHashCode();
        if (WhenActive != 0) hash ^= WhenActive.GetHashCode();
        return hash;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override string ToString() {
        return pb::JsonFormatter.ToDiagnosticString(this);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void WriteTo(pb::CodedOutputStream output) {
        if (Binding != 0) {
          output.WriteRawTag(8);
          output.WriteEnum((int) Binding);
        }
        if (WhenActive != 0) {
          output.WriteRawTag(16);
          output.WriteEnum((int) WhenActive);
        }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public int CalculateSize() {
        int size = 0;
        if (Binding != 0) {
          size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Binding);
        }
        if (WhenActive != 0) {
          size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) WhenActive);
        }
        return size;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void MergeFrom(KeyboardActionContainer other) {
        if (other == null) {
          return;
        }
        if (other.Binding != 0) {
          Binding = other.Binding;
        }
        if (other.WhenActive != 0) {
          WhenActive = other.WhenActive;
        }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void MergeFrom(pb::CodedInputStream input) {
        uint tag;
        while ((tag = input.ReadTag()) != 0) {
          switch(tag) {
            default:
              input.SkipLastField();
              break;
            case 8: {
              binding_ = (global::TypingControl.Types.KeyboardAction) input.ReadEnum();
              break;
            }
            case 16: {
              whenActive_ = (global::TypingControl.Types.ActiveWhen) input.ReadEnum();
              break;
            }
          }
        }
      }

    }

  }
  #endregion

}

public sealed partial class KeyboardSet : pb::IMessage<KeyboardSet> {
  private static readonly pb::MessageParser<KeyboardSet> _parser = new pb::MessageParser<KeyboardSet>(() => new KeyboardSet());
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<KeyboardSet> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::KeyboardControlReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public KeyboardSet() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public KeyboardSet(KeyboardSet other) : this() {
    count_ = other.count_;
    subcount_ = other.subcount_;
    set_ = other.set_.Clone();
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public KeyboardSet Clone() {
    return new KeyboardSet(this);
  }

  /// <summary>Field number for the "count" field.</summary>
  public const int CountFieldNumber = 1;
  private int count_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int Count {
    get { return count_; }
    set {
      count_ = value;
    }
  }

  /// <summary>Field number for the "subcount" field.</summary>
  public const int SubcountFieldNumber = 2;
  private int subcount_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int Subcount {
    get { return subcount_; }
    set {
      subcount_ = value;
    }
  }

  /// <summary>Field number for the "set" field.</summary>
  public const int SetFieldNumber = 3;
  private static readonly pb::FieldCodec<global::KeyboardSet.Types.StringChoice> _repeated_set_codec
      = pb::FieldCodec.ForMessage(26, global::KeyboardSet.Types.StringChoice.Parser);
  private readonly pbc::RepeatedField<global::KeyboardSet.Types.StringChoice> set_ = new pbc::RepeatedField<global::KeyboardSet.Types.StringChoice>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<global::KeyboardSet.Types.StringChoice> Set {
    get { return set_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as KeyboardSet);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(KeyboardSet other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Count != other.Count) return false;
    if (Subcount != other.Subcount) return false;
    if(!set_.Equals(other.set_)) return false;
    return true;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Count != 0) hash ^= Count.GetHashCode();
    if (Subcount != 0) hash ^= Subcount.GetHashCode();
    hash ^= set_.GetHashCode();
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (Count != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(Count);
    }
    if (Subcount != 0) {
      output.WriteRawTag(16);
      output.WriteInt32(Subcount);
    }
    set_.WriteTo(output, _repeated_set_codec);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Count != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Count);
    }
    if (Subcount != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Subcount);
    }
    size += set_.CalculateSize(_repeated_set_codec);
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(KeyboardSet other) {
    if (other == null) {
      return;
    }
    if (other.Count != 0) {
      Count = other.Count;
    }
    if (other.Subcount != 0) {
      Subcount = other.Subcount;
    }
    set_.Add(other.set_);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          input.SkipLastField();
          break;
        case 8: {
          Count = input.ReadInt32();
          break;
        }
        case 16: {
          Subcount = input.ReadInt32();
          break;
        }
        case 26: {
          set_.AddEntriesFrom(input, _repeated_set_codec);
          break;
        }
      }
    }
  }

  #region Nested types
  /// <summary>Container for nested types declared in the KeyboardSet message type.</summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static partial class Types {
    public sealed partial class StringChoice : pb::IMessage<StringChoice> {
      private static readonly pb::MessageParser<StringChoice> _parser = new pb::MessageParser<StringChoice>(() => new StringChoice());
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public static pb::MessageParser<StringChoice> Parser { get { return _parser; } }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public static pbr::MessageDescriptor Descriptor {
        get { return global::KeyboardSet.Descriptor.NestedTypes[0]; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      pbr::MessageDescriptor pb::IMessage.Descriptor {
        get { return Descriptor; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public StringChoice() {
        OnConstruction();
      }

      partial void OnConstruction();

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public StringChoice(StringChoice other) : this() {
        display_ = other.display_;
        subset_ = other.subset_.Clone();
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public StringChoice Clone() {
        return new StringChoice(this);
      }

      /// <summary>Field number for the "display" field.</summary>
      public const int DisplayFieldNumber = 1;
      private string display_ = "";
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public string Display {
        get { return display_; }
        set {
          display_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        }
      }

      /// <summary>Field number for the "subset" field.</summary>
      public const int SubsetFieldNumber = 2;
      private static readonly pb::FieldCodec<string> _repeated_subset_codec
          = pb::FieldCodec.ForString(18);
      private readonly pbc::RepeatedField<string> subset_ = new pbc::RepeatedField<string>();
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public pbc::RepeatedField<string> Subset {
        get { return subset_; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override bool Equals(object other) {
        return Equals(other as StringChoice);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public bool Equals(StringChoice other) {
        if (ReferenceEquals(other, null)) {
          return false;
        }
        if (ReferenceEquals(other, this)) {
          return true;
        }
        if (Display != other.Display) return false;
        if(!subset_.Equals(other.subset_)) return false;
        return true;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override int GetHashCode() {
        int hash = 1;
        if (Display.Length != 0) hash ^= Display.GetHashCode();
        hash ^= subset_.GetHashCode();
        return hash;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override string ToString() {
        return pb::JsonFormatter.ToDiagnosticString(this);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void WriteTo(pb::CodedOutputStream output) {
        if (Display.Length != 0) {
          output.WriteRawTag(10);
          output.WriteString(Display);
        }
        subset_.WriteTo(output, _repeated_subset_codec);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public int CalculateSize() {
        int size = 0;
        if (Display.Length != 0) {
          size += 1 + pb::CodedOutputStream.ComputeStringSize(Display);
        }
        size += subset_.CalculateSize(_repeated_subset_codec);
        return size;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void MergeFrom(StringChoice other) {
        if (other == null) {
          return;
        }
        if (other.Display.Length != 0) {
          Display = other.Display;
        }
        subset_.Add(other.subset_);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void MergeFrom(pb::CodedInputStream input) {
        uint tag;
        while ((tag = input.ReadTag()) != 0) {
          switch(tag) {
            default:
              input.SkipLastField();
              break;
            case 10: {
              Display = input.ReadString();
              break;
            }
            case 18: {
              subset_.AddEntriesFrom(input, _repeated_subset_codec);
              break;
            }
          }
        }
      }

    }

  }
  #endregion

}

#endregion


#endregion Designer generated code
