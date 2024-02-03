#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif





// UnityEngine.Material[]
struct MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D;
// UnityEngine.Renderer[]
struct RendererU5BU5D_t32FDD782F67917B2291EA4FF242719877440A02A;
// Meta.WitAi.Dictation.DictationService
struct DictationService_t120A3B548978DE9D6F3EF299907186C4AC963F3A;
// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
// UnityEngine.MeshFilter
struct MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5;
// System.String
struct String_t;
// UnityEngine.UI.Text
struct Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62;
// TMPro.TextMeshProUGUI
struct TextMeshProUGUI_t101091AF4B578BB534C92E9D1EEAF0611636D957;
// UnityEngine.Transform
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Attribute
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA  : public RuntimeObject
{
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

// Meta.Voice.Hub.Attributes.MetaHubContextAttribute
struct MetaHubContextAttribute_tC8B4A73CCF5AE7EBC573B4B6FA447B0DB69E4435  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	// System.String Meta.Voice.Hub.Attributes.MetaHubContextAttribute::<Context>k__BackingField
	String_t* ___U3CContextU3Ek__BackingField_0;
	// System.Int32 Meta.Voice.Hub.Attributes.MetaHubContextAttribute::<Priority>k__BackingField
	int32_t ___U3CPriorityU3Ek__BackingField_1;
	// System.String Meta.Voice.Hub.Attributes.MetaHubContextAttribute::<LogoPath>k__BackingField
	String_t* ___U3CLogoPathU3Ek__BackingField_2;
};

// Meta.Voice.Hub.Attributes.MetaHubPageAttribute
struct MetaHubPageAttribute_t519882E9F4F4601D821160FD0CB647FC66547F96  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	// System.String Meta.Voice.Hub.Attributes.MetaHubPageAttribute::<Name>k__BackingField
	String_t* ___U3CNameU3Ek__BackingField_0;
	// System.String Meta.Voice.Hub.Attributes.MetaHubPageAttribute::<Context>k__BackingField
	String_t* ___U3CContextU3Ek__BackingField_1;
	// System.Int32 Meta.Voice.Hub.Attributes.MetaHubPageAttribute::<Priority>k__BackingField
	int32_t ___U3CPriorityU3Ek__BackingField_2;
	// System.String Meta.Voice.Hub.Attributes.MetaHubPageAttribute::<Prefix>k__BackingField
	String_t* ___U3CPrefixU3Ek__BackingField_3;
};

// UnityEngine.Vector3
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;
};

// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;
};
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

// Meta.XR.BuildingBlocks.BuildingBlock
struct BuildingBlock_tDE9B8AC1251664C7713EF3D9E6F922DDA04305AB  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.String Meta.XR.BuildingBlocks.BuildingBlock::blockId
	String_t* ___blockId_4;
	// System.String Meta.XR.BuildingBlocks.BuildingBlock::instanceId
	String_t* ___instanceId_5;
	// System.Int32 Meta.XR.BuildingBlocks.BuildingBlock::version
	int32_t ___version_6;
};

// Meta.Voice.Samples.Chess.ChessBoardController
struct ChessBoardController_tE05F88AD1A6DA10A34C5734C342D6E01A465DD2B  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// UnityEngine.GameObject Meta.Voice.Samples.Chess.ChessBoardController::letters
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___letters_4;
	// UnityEngine.GameObject Meta.Voice.Samples.Chess.ChessBoardController::numbers
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___numbers_5;
	// UnityEngine.GameObject Meta.Voice.Samples.Chess.ChessBoardController::chessPiece
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___chessPiece_6;
	// UnityEngine.UI.Text Meta.Voice.Samples.Chess.ChessBoardController::errorText
	Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62* ___errorText_7;
	// UnityEngine.Vector3 Meta.Voice.Samples.Chess.ChessBoardController::_targetPosition
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ____targetPosition_8;
};

// Meta.Voice.Samples.Dictation.DictationActivation
struct DictationActivation_t1C5F9FFA3E18891AB07D458A07E850190502EBD2  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// Meta.WitAi.Dictation.DictationService Meta.Voice.Samples.Dictation.DictationActivation::_dictation
	DictationService_t120A3B548978DE9D6F3EF299907186C4AC963F3A* ____dictation_4;
};

// Meta.Voice.Samples.LightTraits.LightSwitch
struct LightSwitch_tD5C86BCFFC78D0810485CAE23D2A2B3E89ABB6FE  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// UnityEngine.Renderer[] Meta.Voice.Samples.LightTraits.LightSwitch::_renderers
	RendererU5BU5D_t32FDD782F67917B2291EA4FF242719877440A02A* ____renderers_4;
	// UnityEngine.Material[] Meta.Voice.Samples.LightTraits.LightSwitch::_offMaterials
	MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* ____offMaterials_5;
	// UnityEngine.Material[] Meta.Voice.Samples.LightTraits.LightSwitch::_onMaterials
	MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* ____onMaterials_6;
	// System.Boolean Meta.Voice.Samples.LightTraits.LightSwitch::<IsOn>k__BackingField
	bool ___U3CIsOnU3Ek__BackingField_7;
};

// Meta.Voice.Samples.LiveUnderstanding.LiveUnderstandingColorChanger
struct LiveUnderstandingColorChanger_t37E852581A43D039D31199E6D88433AC59E99C4A  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// UnityEngine.Transform Meta.Voice.Samples.LiveUnderstanding.LiveUnderstandingColorChanger::_container
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ____container_4;
};

// Meta.XR.BuildingBlocks.PassthroughProjectionSurfaceBuildingBlock
struct PassthroughProjectionSurfaceBuildingBlock_t307B06764005EFF72F4A45F50F9EA42D41D04657  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// UnityEngine.MeshFilter Meta.XR.BuildingBlocks.PassthroughProjectionSurfaceBuildingBlock::projectionObject
	MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* ___projectionObject_4;
};

// Meta.Voice.Samples.Dictation.SimpleLabelResizer
struct SimpleLabelResizer_t07C2D3BF2DDDF56F9E5967B1CE126BC3B2CA2070  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// TMPro.TextMeshProUGUI Meta.Voice.Samples.Dictation.SimpleLabelResizer::_label
	TextMeshProUGUI_t101091AF4B578BB534C92E9D1EEAF0611636D957* ____label_4;
	// System.String Meta.Voice.Samples.Dictation.SimpleLabelResizer::_text
	String_t* ____text_5;
};

// Meta.Voice.Hub.Attributes.MetaHubContextAttribute

// Meta.Voice.Hub.Attributes.MetaHubContextAttribute

// Meta.Voice.Hub.Attributes.MetaHubPageAttribute

// Meta.Voice.Hub.Attributes.MetaHubPageAttribute

// Meta.XR.BuildingBlocks.BuildingBlock

// Meta.XR.BuildingBlocks.BuildingBlock

// Meta.Voice.Samples.Chess.ChessBoardController

// Meta.Voice.Samples.Chess.ChessBoardController

// Meta.Voice.Samples.Dictation.DictationActivation

// Meta.Voice.Samples.Dictation.DictationActivation

// Meta.Voice.Samples.LightTraits.LightSwitch

// Meta.Voice.Samples.LightTraits.LightSwitch

// Meta.Voice.Samples.LiveUnderstanding.LiveUnderstandingColorChanger

// Meta.Voice.Samples.LiveUnderstanding.LiveUnderstandingColorChanger

// Meta.XR.BuildingBlocks.PassthroughProjectionSurfaceBuildingBlock

// Meta.XR.BuildingBlocks.PassthroughProjectionSurfaceBuildingBlock

// Meta.Voice.Samples.Dictation.SimpleLabelResizer

// Meta.Voice.Samples.Dictation.SimpleLabelResizer
#ifdef __clang__
#pragma clang diagnostic pop
#endif



#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9007[3] = 
{
	static_cast<int32_t>(offsetof(MetaHubContextAttribute_tC8B4A73CCF5AE7EBC573B4B6FA447B0DB69E4435, ___U3CContextU3Ek__BackingField_0)),static_cast<int32_t>(offsetof(MetaHubContextAttribute_tC8B4A73CCF5AE7EBC573B4B6FA447B0DB69E4435, ___U3CPriorityU3Ek__BackingField_1)),static_cast<int32_t>(offsetof(MetaHubContextAttribute_tC8B4A73CCF5AE7EBC573B4B6FA447B0DB69E4435, ___U3CLogoPathU3Ek__BackingField_2)),};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9008[4] = 
{
	static_cast<int32_t>(offsetof(MetaHubPageAttribute_t519882E9F4F4601D821160FD0CB647FC66547F96, ___U3CNameU3Ek__BackingField_0)),static_cast<int32_t>(offsetof(MetaHubPageAttribute_t519882E9F4F4601D821160FD0CB647FC66547F96, ___U3CContextU3Ek__BackingField_1)),static_cast<int32_t>(offsetof(MetaHubPageAttribute_t519882E9F4F4601D821160FD0CB647FC66547F96, ___U3CPriorityU3Ek__BackingField_2)),static_cast<int32_t>(offsetof(MetaHubPageAttribute_t519882E9F4F4601D821160FD0CB647FC66547F96, ___U3CPrefixU3Ek__BackingField_3)),};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9011[9] = 
{
	static_cast<int32_t>(sizeof(RuntimeObject)),0,0,0,0,0,0,0,0,};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9012[5] = 
{
	static_cast<int32_t>(offsetof(ChessBoardController_tE05F88AD1A6DA10A34C5734C342D6E01A465DD2B, ___letters_4)),static_cast<int32_t>(offsetof(ChessBoardController_tE05F88AD1A6DA10A34C5734C342D6E01A465DD2B, ___numbers_5)),static_cast<int32_t>(offsetof(ChessBoardController_tE05F88AD1A6DA10A34C5734C342D6E01A465DD2B, ___chessPiece_6)),static_cast<int32_t>(offsetof(ChessBoardController_tE05F88AD1A6DA10A34C5734C342D6E01A465DD2B, ___errorText_7)),static_cast<int32_t>(offsetof(ChessBoardController_tE05F88AD1A6DA10A34C5734C342D6E01A465DD2B, ____targetPosition_8)),};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9014[3] = 
{
	static_cast<int32_t>(offsetof(BuildingBlock_tDE9B8AC1251664C7713EF3D9E6F922DDA04305AB, ___blockId_4)),static_cast<int32_t>(offsetof(BuildingBlock_tDE9B8AC1251664C7713EF3D9E6F922DDA04305AB, ___instanceId_5)),static_cast<int32_t>(offsetof(BuildingBlock_tDE9B8AC1251664C7713EF3D9E6F922DDA04305AB, ___version_6)),};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9015[1] = 
{
	static_cast<int32_t>(offsetof(PassthroughProjectionSurfaceBuildingBlock_t307B06764005EFF72F4A45F50F9EA42D41D04657, ___projectionObject_4)),};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9018[1] = 
{
	static_cast<int32_t>(offsetof(DictationActivation_t1C5F9FFA3E18891AB07D458A07E850190502EBD2, ____dictation_4)),};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9019[2] = 
{
	static_cast<int32_t>(offsetof(SimpleLabelResizer_t07C2D3BF2DDDF56F9E5967B1CE126BC3B2CA2070, ____label_4)),static_cast<int32_t>(offsetof(SimpleLabelResizer_t07C2D3BF2DDDF56F9E5967B1CE126BC3B2CA2070, ____text_5)),};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9021[6] = 
{
	static_cast<int32_t>(offsetof(LightSwitch_tD5C86BCFFC78D0810485CAE23D2A2B3E89ABB6FE, ____renderers_4)),static_cast<int32_t>(offsetof(LightSwitch_tD5C86BCFFC78D0810485CAE23D2A2B3E89ABB6FE, ____offMaterials_5)),static_cast<int32_t>(offsetof(LightSwitch_tD5C86BCFFC78D0810485CAE23D2A2B3E89ABB6FE, ____onMaterials_6)),static_cast<int32_t>(offsetof(LightSwitch_tD5C86BCFFC78D0810485CAE23D2A2B3E89ABB6FE, ___U3CIsOnU3Ek__BackingField_7)),0,0,};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9023[3] = 
{
	static_cast<int32_t>(offsetof(LiveUnderstandingColorChanger_t37E852581A43D039D31199E6D88433AC59E99C4A, ____container_4)),0,0,};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9026[15] = 
{
	static_cast<int32_t>(sizeof(RuntimeObject)),0,0,0,0,0,0,0,0,0,0,0,0,0,0,};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9027[5] = 
{
	static_cast<int32_t>(sizeof(RuntimeObject)),0,0,0,0,};
IL2CPP_EXTERN_C const int32_t g_FieldOffsetTable9031[4] = 
{
	static_cast<int32_t>(sizeof(RuntimeObject)),0,0,0,};
