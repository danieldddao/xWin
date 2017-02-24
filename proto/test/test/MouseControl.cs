// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: mouse_control.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from mouse_control.proto</summary>
public static partial class MouseControlReflection {

  #region Descriptor
  /// <summary>File descriptor for mouse_control.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static MouseControlReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChNtb3VzZV9jb250cm9sLnByb3RvItgGCg1Db25maWd1cmF0aW9uEisKDW1v",
          "dXNlX2NvbnRyb2wYASABKAsyFC5Db25maWd1cmF0aW9uLlN0aWNrEhcKD2lu",
          "dmVydF9VRF9tb3VzZRgCIAEoCBIXCg9pbnZlcnRfTFJfbW91c2UYAyABKAgS",
          "EwoLc2Vuc2l0aXZpdHkYBCABKAISMwoKbGVmdF9jbGljaxgFIAEoDjIfLkNv",
          "bmZpZ3VyYXRpb24uQ29udHJvbGxlckJ1dHRvbhI0CgtyaWdodF9jbGljaxgG",
          "IAEoDjIfLkNvbmZpZ3VyYXRpb24uQ29udHJvbGxlckJ1dHRvbhpaCgVTdGlj",
          "axIqCgFzGAEgASgOMh8uQ29uZmlndXJhdGlvbi5Db250cm9sbGVyU3RpY2tz",
          "EhEKCXRocmVzaG9sZBgDIAEoAhISCgptb3ZlX21vdXNlGAIgASgIItgDChBD",
          "b250cm9sbGVyQnV0dG9uEggKBE5PTkUQABIGCgJMUxABEgYKAlJTEAISBgoC",
          "TEIQAxIGCgJSQhAEEgYKAkxUEAUSBgoCUlQQBhIFCgFBEAcSBQoBQhAIEgUK",
          "AVgQCRIFCgFZEAoSCAoETUVOVRALEggKBFZJRVcQDBIICgRYQk9YEA0SBwoD",
          "TFRIEA4SBwoDUlRIEA8SBwoDTFMwEBASBwoDTFMxEBESBwoDTFMyEBISBwoD",
          "TFMzEBMSBwoDTFM0EBQSBwoDTFM1EBUSBwoDTFM2EBYSBwoDTFM3EBcSBwoD",
          "TFM4EBgSBwoDTFM5EBkSBwoDTFNBEBoSBwoDTFNCEBsSBwoDTFNDEBwSBwoD",
          "TFNEEB0SBwoDTFNFEB4SBwoDTFNGEB8SBwoDUlMwECASBwoDUlMxECESBwoD",
          "UlMyECISBwoDUlMzECMSBwoDUlM0ECQSBwoDUlM1ECUSBwoDUlM2ECYSBwoD",
          "UlM3ECcSBwoDUlM4ECgSBwoDUlM5ECkSBwoDUlNBECoSBwoDUlNCECsSBwoD",
          "UlNDECwSBwoDUlNEEC0SBwoDUlNFEC4SBwoDUlNGEC8SBgoCRFUQMxIGCgJE",
          "UhA0EgYKAkREEDUSBgoCREwQNiIxChBDb250cm9sbGVyU3RpY2tzEg0KCUxF",
          "RlRTVElDSxAAEg4KClJJR0hUU1RJQ0sQAWIGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::Configuration), global::Configuration.Parser, new[]{ "MouseControl", "InvertUDMouse", "InvertLRMouse", "Sensitivity", "LeftClick", "RightClick" }, null, new[]{ typeof(global::Configuration.Types.ControllerButton), typeof(global::Configuration.Types.ControllerSticks) }, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Configuration.Types.Stick), global::Configuration.Types.Stick.Parser, new[]{ "S", "Threshold", "MoveMouse" }, null, null, null)})
        }));
  }
  #endregion

}
#region Messages
public sealed partial class Configuration : pb::IMessage<Configuration> {
  private static readonly pb::MessageParser<Configuration> _parser = new pb::MessageParser<Configuration>(() => new Configuration());
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<Configuration> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::MouseControlReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Configuration() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Configuration(Configuration other) : this() {
    MouseControl = other.mouseControl_ != null ? other.MouseControl.Clone() : null;
    invertUDMouse_ = other.invertUDMouse_;
    invertLRMouse_ = other.invertLRMouse_;
    sensitivity_ = other.sensitivity_;
    leftClick_ = other.leftClick_;
    rightClick_ = other.rightClick_;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Configuration Clone() {
    return new Configuration(this);
  }

  /// <summary>Field number for the "mouse_control" field.</summary>
  public const int MouseControlFieldNumber = 1;
  private global::Configuration.Types.Stick mouseControl_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::Configuration.Types.Stick MouseControl {
    get { return mouseControl_; }
    set {
      mouseControl_ = value;
    }
  }

  /// <summary>Field number for the "invert_UD_mouse" field.</summary>
  public const int InvertUDMouseFieldNumber = 2;
  private bool invertUDMouse_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool InvertUDMouse {
    get { return invertUDMouse_; }
    set {
      invertUDMouse_ = value;
    }
  }

  /// <summary>Field number for the "invert_LR_mouse" field.</summary>
  public const int InvertLRMouseFieldNumber = 3;
  private bool invertLRMouse_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool InvertLRMouse {
    get { return invertLRMouse_; }
    set {
      invertLRMouse_ = value;
    }
  }

  /// <summary>Field number for the "sensitivity" field.</summary>
  public const int SensitivityFieldNumber = 4;
  private float sensitivity_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public float Sensitivity {
    get { return sensitivity_; }
    set {
      sensitivity_ = value;
    }
  }

  /// <summary>Field number for the "left_click" field.</summary>
  public const int LeftClickFieldNumber = 5;
  private global::Configuration.Types.ControllerButton leftClick_ = 0;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::Configuration.Types.ControllerButton LeftClick {
    get { return leftClick_; }
    set {
      leftClick_ = value;
    }
  }

  /// <summary>Field number for the "right_click" field.</summary>
  public const int RightClickFieldNumber = 6;
  private global::Configuration.Types.ControllerButton rightClick_ = 0;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::Configuration.Types.ControllerButton RightClick {
    get { return rightClick_; }
    set {
      rightClick_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as Configuration);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(Configuration other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (!object.Equals(MouseControl, other.MouseControl)) return false;
    if (InvertUDMouse != other.InvertUDMouse) return false;
    if (InvertLRMouse != other.InvertLRMouse) return false;
    if (Sensitivity != other.Sensitivity) return false;
    if (LeftClick != other.LeftClick) return false;
    if (RightClick != other.RightClick) return false;
    return true;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (mouseControl_ != null) hash ^= MouseControl.GetHashCode();
    if (InvertUDMouse != false) hash ^= InvertUDMouse.GetHashCode();
    if (InvertLRMouse != false) hash ^= InvertLRMouse.GetHashCode();
    if (Sensitivity != 0F) hash ^= Sensitivity.GetHashCode();
    if (LeftClick != 0) hash ^= LeftClick.GetHashCode();
    if (RightClick != 0) hash ^= RightClick.GetHashCode();
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (mouseControl_ != null) {
      output.WriteRawTag(10);
      output.WriteMessage(MouseControl);
    }
    if (InvertUDMouse != false) {
      output.WriteRawTag(16);
      output.WriteBool(InvertUDMouse);
    }
    if (InvertLRMouse != false) {
      output.WriteRawTag(24);
      output.WriteBool(InvertLRMouse);
    }
    if (Sensitivity != 0F) {
      output.WriteRawTag(37);
      output.WriteFloat(Sensitivity);
    }
    if (LeftClick != 0) {
      output.WriteRawTag(40);
      output.WriteEnum((int) LeftClick);
    }
    if (RightClick != 0) {
      output.WriteRawTag(48);
      output.WriteEnum((int) RightClick);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (mouseControl_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(MouseControl);
    }
    if (InvertUDMouse != false) {
      size += 1 + 1;
    }
    if (InvertLRMouse != false) {
      size += 1 + 1;
    }
    if (Sensitivity != 0F) {
      size += 1 + 4;
    }
    if (LeftClick != 0) {
      size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) LeftClick);
    }
    if (RightClick != 0) {
      size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) RightClick);
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(Configuration other) {
    if (other == null) {
      return;
    }
    if (other.mouseControl_ != null) {
      if (mouseControl_ == null) {
        mouseControl_ = new global::Configuration.Types.Stick();
      }
      MouseControl.MergeFrom(other.MouseControl);
    }
    if (other.InvertUDMouse != false) {
      InvertUDMouse = other.InvertUDMouse;
    }
    if (other.InvertLRMouse != false) {
      InvertLRMouse = other.InvertLRMouse;
    }
    if (other.Sensitivity != 0F) {
      Sensitivity = other.Sensitivity;
    }
    if (other.LeftClick != 0) {
      LeftClick = other.LeftClick;
    }
    if (other.RightClick != 0) {
      RightClick = other.RightClick;
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
        case 10: {
          if (mouseControl_ == null) {
            mouseControl_ = new global::Configuration.Types.Stick();
          }
          input.ReadMessage(mouseControl_);
          break;
        }
        case 16: {
          InvertUDMouse = input.ReadBool();
          break;
        }
        case 24: {
          InvertLRMouse = input.ReadBool();
          break;
        }
        case 37: {
          Sensitivity = input.ReadFloat();
          break;
        }
        case 40: {
          leftClick_ = (global::Configuration.Types.ControllerButton) input.ReadEnum();
          break;
        }
        case 48: {
          rightClick_ = (global::Configuration.Types.ControllerButton) input.ReadEnum();
          break;
        }
      }
    }
  }

  #region Nested types
  /// <summary>Container for nested types declared in the Configuration message type.</summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static partial class Types {
    public enum ControllerButton {
      [pbr::OriginalName("NONE")] None = 0,
      /// <summary>
      ///Stick Press
      /// </summary>
      [pbr::OriginalName("LS")] Ls = 1,
      [pbr::OriginalName("RS")] Rs = 2,
      /// <summary>
      ///Bumper
      /// </summary>
      [pbr::OriginalName("LB")] Lb = 3,
      [pbr::OriginalName("RB")] Rb = 4,
      /// <summary>
      ///Trigger
      /// </summary>
      [pbr::OriginalName("LT")] Lt = 5,
      [pbr::OriginalName("RT")] Rt = 6,
      [pbr::OriginalName("A")] A = 7,
      [pbr::OriginalName("B")] B = 8,
      [pbr::OriginalName("X")] X = 9,
      [pbr::OriginalName("Y")] Y = 10,
      [pbr::OriginalName("MENU")] Menu = 11,
      [pbr::OriginalName("VIEW")] View = 12,
      [pbr::OriginalName("XBOX")] Xbox = 13,
      /// <summary>
      ///half trigger pull
      /// </summary>
      [pbr::OriginalName("LTH")] Lth = 14,
      [pbr::OriginalName("RTH")] Rth = 15,
      /// <summary>
      ///Stick Regions
      /// </summary>
      [pbr::OriginalName("LS0")] Ls0 = 16,
      [pbr::OriginalName("LS1")] Ls1 = 17,
      [pbr::OriginalName("LS2")] Ls2 = 18,
      [pbr::OriginalName("LS3")] Ls3 = 19,
      [pbr::OriginalName("LS4")] Ls4 = 20,
      [pbr::OriginalName("LS5")] Ls5 = 21,
      [pbr::OriginalName("LS6")] Ls6 = 22,
      [pbr::OriginalName("LS7")] Ls7 = 23,
      [pbr::OriginalName("LS8")] Ls8 = 24,
      [pbr::OriginalName("LS9")] Ls9 = 25,
      [pbr::OriginalName("LSA")] Lsa = 26,
      [pbr::OriginalName("LSB")] Lsb = 27,
      [pbr::OriginalName("LSC")] Lsc = 28,
      [pbr::OriginalName("LSD")] Lsd = 29,
      [pbr::OriginalName("LSE")] Lse = 30,
      [pbr::OriginalName("LSF")] Lsf = 31,
      [pbr::OriginalName("RS0")] Rs0 = 32,
      [pbr::OriginalName("RS1")] Rs1 = 33,
      [pbr::OriginalName("RS2")] Rs2 = 34,
      [pbr::OriginalName("RS3")] Rs3 = 35,
      [pbr::OriginalName("RS4")] Rs4 = 36,
      [pbr::OriginalName("RS5")] Rs5 = 37,
      [pbr::OriginalName("RS6")] Rs6 = 38,
      [pbr::OriginalName("RS7")] Rs7 = 39,
      [pbr::OriginalName("RS8")] Rs8 = 40,
      [pbr::OriginalName("RS9")] Rs9 = 41,
      [pbr::OriginalName("RSA")] Rsa = 42,
      [pbr::OriginalName("RSB")] Rsb = 43,
      [pbr::OriginalName("RSC")] Rsc = 44,
      [pbr::OriginalName("RSD")] Rsd = 45,
      [pbr::OriginalName("RSE")] Rse = 46,
      [pbr::OriginalName("RSF")] Rsf = 47,
      [pbr::OriginalName("DU")] Du = 51,
      [pbr::OriginalName("DR")] Dr = 52,
      [pbr::OriginalName("DD")] Dd = 53,
      [pbr::OriginalName("DL")] Dl = 54,
    }

    public enum ControllerSticks {
      [pbr::OriginalName("LEFTSTICK")] Leftstick = 0,
      [pbr::OriginalName("RIGHTSTICK")] Rightstick = 1,
    }

    public sealed partial class Stick : pb::IMessage<Stick> {
      private static readonly pb::MessageParser<Stick> _parser = new pb::MessageParser<Stick>(() => new Stick());
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public static pb::MessageParser<Stick> Parser { get { return _parser; } }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public static pbr::MessageDescriptor Descriptor {
        get { return global::Configuration.Descriptor.NestedTypes[0]; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      pbr::MessageDescriptor pb::IMessage.Descriptor {
        get { return Descriptor; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public Stick() {
        OnConstruction();
      }

      partial void OnConstruction();

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public Stick(Stick other) : this() {
        s_ = other.s_;
        threshold_ = other.threshold_;
        moveMouse_ = other.moveMouse_;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public Stick Clone() {
        return new Stick(this);
      }

      /// <summary>Field number for the "s" field.</summary>
      public const int SFieldNumber = 1;
      private global::Configuration.Types.ControllerSticks s_ = 0;
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public global::Configuration.Types.ControllerSticks S {
        get { return s_; }
        set {
          s_ = value;
        }
      }

      /// <summary>Field number for the "threshold" field.</summary>
      public const int ThresholdFieldNumber = 3;
      private float threshold_;
      /// <summary>
      ///how far must the stick go to count as moved
      /// </summary>
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public float Threshold {
        get { return threshold_; }
        set {
          threshold_ = value;
        }
      }

      /// <summary>Field number for the "move_mouse" field.</summary>
      public const int MoveMouseFieldNumber = 2;
      private bool moveMouse_;
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public bool MoveMouse {
        get { return moveMouse_; }
        set {
          moveMouse_ = value;
        }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override bool Equals(object other) {
        return Equals(other as Stick);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public bool Equals(Stick other) {
        if (ReferenceEquals(other, null)) {
          return false;
        }
        if (ReferenceEquals(other, this)) {
          return true;
        }
        if (S != other.S) return false;
        if (Threshold != other.Threshold) return false;
        if (MoveMouse != other.MoveMouse) return false;
        return true;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override int GetHashCode() {
        int hash = 1;
        if (S != 0) hash ^= S.GetHashCode();
        if (Threshold != 0F) hash ^= Threshold.GetHashCode();
        if (MoveMouse != false) hash ^= MoveMouse.GetHashCode();
        return hash;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override string ToString() {
        return pb::JsonFormatter.ToDiagnosticString(this);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void WriteTo(pb::CodedOutputStream output) {
        if (S != 0) {
          output.WriteRawTag(8);
          output.WriteEnum((int) S);
        }
        if (MoveMouse != false) {
          output.WriteRawTag(16);
          output.WriteBool(MoveMouse);
        }
        if (Threshold != 0F) {
          output.WriteRawTag(29);
          output.WriteFloat(Threshold);
        }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public int CalculateSize() {
        int size = 0;
        if (S != 0) {
          size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) S);
        }
        if (Threshold != 0F) {
          size += 1 + 4;
        }
        if (MoveMouse != false) {
          size += 1 + 1;
        }
        return size;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void MergeFrom(Stick other) {
        if (other == null) {
          return;
        }
        if (other.S != 0) {
          S = other.S;
        }
        if (other.Threshold != 0F) {
          Threshold = other.Threshold;
        }
        if (other.MoveMouse != false) {
          MoveMouse = other.MoveMouse;
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
              s_ = (global::Configuration.Types.ControllerSticks) input.ReadEnum();
              break;
            }
            case 16: {
              MoveMouse = input.ReadBool();
              break;
            }
            case 29: {
              Threshold = input.ReadFloat();
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