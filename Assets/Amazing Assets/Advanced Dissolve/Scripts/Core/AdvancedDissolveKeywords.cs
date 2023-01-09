using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
    public static class AdvancedDissolveKeywords
    {
        public enum State
        {
            Disabled,
            Enabled
        }

        public enum CutoutStandardSource
        {
            None,
            BaseAlpha,
            CustomMap,
            TwoCustomMaps,
            ThreeCustomMaps,
            UserDefined
        }

        public enum CutoutStandardSourceMapsMappingType
        {
            Default,
            Triplanar,
            ScreenSpace
        }

        public enum CutoutGeometricType
        {
            None,
            XYZAxis,
            Plane,
            Sphere,
            Cube,
            Capsule,
            ConeSmooth
        }

        public enum CutoutGeometricCount
        {
            One,
            Two,
            Three,
            Four
        }

        public enum EdgeBaseSource
        {
            None,
            CutoutStandard,
            CutoutGeometric,
            All
        }

        public enum EdgeAdditionalColorSource
        {
            None,
            BaseColor,
            CustomMap,
            GradientMap,
            GradientColor,
            UserDefined
        }

        public enum EdgeUVDistortionSource
        {
            Default,
            CustomMap
        }

        public enum GlobalControlID
        {
            None,
            One,
            Two,
            Three,
            Four
        }


        enum EnumID
        {
            State,
            CutoutStandardSource,
            CutoutStandardSourceMapsMappingType,
            CutoutGeometricType,
            CutoutGeometricCount,
            EdgeBaseSource,
            EdgeAdditionalColorSource,
            EdgeUVDistortionSource,
            GlobalControlID
        }


        static string[][] enumNames =
        {
            new[] {"_AD_STATE_DISABLED", "_AD_STATE_ENABLED"},
            new[] {"_AD_CUTOUT_STANDARD_SOURCE_NONE", "_AD_CUTOUT_STANDARD_SOURCE_BASE_ALPHA", "_AD_CUTOUT_STANDARD_SOURCE_CUSTOM_MAP", "_AD_CUTOUT_STANDARD_SOURCE_TWO_CUSTOM_MAPS", "_AD_CUTOUT_STANDARD_SOURCE_THREE_CUSTOM_MAPS", "_AD_CUTOUT_STANDARD_SOURCE_USER_DEFINED"},
            new[] {"_AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_DEFAULT", "_AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_TRIPLANAR", "_AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_SCREEN_SPACE"},
            new[] {"_AD_CUTOUT_GEOMETRIC_TYPE_NONE", "_AD_CUTOUT_GEOMETRIC_TYPE_XYZ", "_AD_CUTOUT_GEOMETRIC_TYPE_PLANE", "_AD_CUTOUT_GEOMETRIC_TYPE_SPHERE", "_AD_CUTOUT_GEOMETRIC_TYPE_CUBE", "_AD_CUTOUT_GEOMETRIC_TYPE_CAPSULE", "_AD_CUTOUT_GEOMETRIC_TYPE_CONE_SMOOTH"},
            new[] {"_AD_CUTOUT_GEOMETRIC_COUNT_ONE", "_AD_CUTOUT_GEOMETRIC_COUNT_TWO", "_AD_CUTOUT_GEOMETRIC_COUNT_THREE", "_AD_CUTOUT_GEOMETRIC_COUNT_FOUR"},
            new[] {"_AD_EDGE_BASE_SOURCE_NONE", "_AD_EDGE_BASE_SOURCE_CUTOUT_STANDARD", "_AD_EDGE_BASE_SOURCE_CUTOUT_GEOMETRIC", "_AD_EDGE_BASE_SOURCE_ALL"},
            new[] {"_AD_EDGE_ADDITIONAL_COLOR_NONE", "_AD_EDGE_ADDITIONAL_COLOR_BASE_COLOR", "_AD_EDGE_ADDITIONAL_COLOR_CUSTOM_MAP", "_AD_EDGE_ADDITIONAL_COLOR_GRADIENT_MAP", "_AD_EDGE_ADDITIONAL_COLOR_GRADIENT_COLOR", "_AD_EDGE_ADDITIONAL_COLOR_USER_DEFINED"},
            new[] {"_AD_EDGE_UV_DISTORTION_SOURCE_DEFAULT", "_AD_EDGE_UV_DISTORTION_SOURCE_CUSTOM_MAP"},
            new[] {"_AD_GLOBAL_CONTROL_ID_NONE", "_AD_GLOBAL_CONTROL_ID_ONE", "_AD_GLOBAL_CONTROL_ID_TWO", "_AD_GLOBAL_CONTROL_ID_THREE", "_AD_GLOBAL_CONTROL_ID_FOUR"}
        };

        static int[] materialKeywordVariables =
        {
            Shader.PropertyToID("_AdvancedDissolveKeywordState"),
            Shader.PropertyToID("_AdvancedDissolveKeywordCutoutStandardSource"),
            Shader.PropertyToID("_AdvancedDissolveKeywordCutoutStandardSourceMapsMappingType"),
            Shader.PropertyToID("_AdvancedDissolveKeywordCutoutGeometricType"),
            Shader.PropertyToID("_AdvancedDissolveKeywordCutoutGeometricCount"),
            Shader.PropertyToID("_AdvancedDissolveKeywordEdgeBaseSource"),
            Shader.PropertyToID("_AdvancedDissolveKeywordEdgeAdditionalColorSource"),
            Shader.PropertyToID("_AdvancedDissolveKeywordEdgeUVDistortionSource"),
            Shader.PropertyToID("_AdvancedDissolveKeywordGlobalControlID")
        };


        public static void GetKeywords(Material material,
            out State state,
            out CutoutStandardSource cutoutStandardSource,
            out CutoutStandardSourceMapsMappingType cutoutStandardSourceMapsMappingType,
            out CutoutGeometricType cutoutGeometricType,
            out CutoutGeometricCount cutoutGeometricCount,
            out EdgeBaseSource edgeBaseSource,
            out EdgeAdditionalColorSource edgeAdditionalColorSource,
            out EdgeUVDistortionSource edgeUVDistortionSource,
            out GlobalControlID globalControlID)
        {
            state = (State) 0;
            cutoutStandardSource = (CutoutStandardSource) 0;
            cutoutStandardSourceMapsMappingType = (CutoutStandardSourceMapsMappingType) 0;
            cutoutGeometricType = (CutoutGeometricType) 0;
            cutoutGeometricCount = (CutoutGeometricCount) 0;
            edgeBaseSource = (EdgeBaseSource) 0;
            edgeAdditionalColorSource = (EdgeAdditionalColorSource) 0;
            edgeUVDistortionSource = (EdgeUVDistortionSource) 0;
            globalControlID = (GlobalControlID) 0;

            if (material == null)
                return;


            GetKeyword(material, out state);
            GetKeyword(material, out cutoutStandardSource);
            GetKeyword(material, out cutoutStandardSourceMapsMappingType);
            GetKeyword(material, out cutoutGeometricType);
            GetKeyword(material, out cutoutGeometricCount);
            GetKeyword(material, out edgeBaseSource);
            GetKeyword(material, out edgeAdditionalColorSource);
            GetKeyword(material, out edgeUVDistortionSource);
            GetKeyword(material, out globalControlID);
        }

        public static void RemoveAll(Material material, bool ignoreState)
        {
            if (ignoreState == false)
            {
                SetKeyword(material, State.Disabled, false);
            }

            SetKeyword(material, (CutoutStandardSource) 0, false);
            SetKeyword(material, (CutoutStandardSourceMapsMappingType) 0, false);
            SetKeyword(material, (CutoutGeometricType) 0, false);
            SetKeyword(material, (CutoutGeometricCount) 0, false);
            SetKeyword(material, (EdgeBaseSource) 0, false);
            SetKeyword(material, (EdgeAdditionalColorSource) 0, false);
            SetKeyword(material, (EdgeUVDistortionSource) 0, false);
            SetKeyword(material, (GlobalControlID) 0, false);
        }

        public static void Reload(Material material)
        {
            if (material == null)
                return;

            SetKeyword(material, (State) material.GetInt(materialKeywordVariables[(int) EnumID.State]), true);
            SetKeyword(material, (CutoutStandardSource) material.GetInt(materialKeywordVariables[(int) EnumID.CutoutStandardSource]), true);
            SetKeyword(material, (CutoutStandardSourceMapsMappingType) material.GetInt(materialKeywordVariables[(int) EnumID.CutoutStandardSourceMapsMappingType]), true);
            SetKeyword(material, (CutoutGeometricType) material.GetInt(materialKeywordVariables[(int) EnumID.CutoutGeometricType]), true);
            SetKeyword(material, (CutoutGeometricCount) material.GetInt(materialKeywordVariables[(int) EnumID.CutoutGeometricCount]), true);
            SetKeyword(material, (EdgeBaseSource) material.GetInt(materialKeywordVariables[(int) EnumID.EdgeBaseSource]), true);
            SetKeyword(material, (EdgeAdditionalColorSource) material.GetInt(materialKeywordVariables[(int) EnumID.EdgeAdditionalColorSource]), true);
            SetKeyword(material, (EdgeUVDistortionSource) material.GetInt(materialKeywordVariables[(int) EnumID.EdgeUVDistortionSource]), true);
            SetKeyword(material, (GlobalControlID) material.GetInt(materialKeywordVariables[(int) EnumID.GlobalControlID]), true);
        }

        public static void GetKeyword(Material material, out State keyword)
        {
            keyword = (State) GetKeywordByMaterialVariable(material, (int) EnumID.State);
        }

        private static void SetKeyword(Material material, State keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.State, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, State keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.State, (int) keyword, enable);
                }
            }
        }

        private static void GetKeyword(Material material, out CutoutStandardSource keyword)
        {
            keyword = (CutoutStandardSource) GetKeywordByMaterialVariable(material, (int) EnumID.CutoutStandardSource);
        }

        public static void SetKeyword(Material material, CutoutStandardSource keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.CutoutStandardSource, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, CutoutStandardSource keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.CutoutStandardSource, (int) keyword, enable);
                }
            }
        }

        public static void GetKeyword(Material material, out CutoutStandardSourceMapsMappingType keyword)
        {
            keyword = (CutoutStandardSourceMapsMappingType) GetKeywordByMaterialVariable(material, (int) EnumID.CutoutStandardSourceMapsMappingType);
        }

        public static void SetKeyword(Material material, CutoutStandardSourceMapsMappingType keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.CutoutStandardSourceMapsMappingType, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, CutoutStandardSourceMapsMappingType keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.CutoutStandardSourceMapsMappingType, (int) keyword, enable);
                }
            }
        }

        public static void GetKeyword(Material material, out CutoutGeometricType keyword)
        {
            keyword = (CutoutGeometricType) GetKeywordByMaterialVariable(material, (int) EnumID.CutoutGeometricType);
        }

        public static void SetKeyword(Material material, CutoutGeometricType keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.CutoutGeometricType, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, CutoutGeometricType keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.CutoutGeometricType, (int) keyword, enable);
                }
            }
        }

        public static void GetKeyword(Material material, out CutoutGeometricCount keyword)
        {
            keyword = (CutoutGeometricCount) GetKeywordByMaterialVariable(material, (int) EnumID.CutoutGeometricCount);
        }

        public static void SetKeyword(Material material, CutoutGeometricCount keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.CutoutGeometricCount, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, CutoutGeometricCount keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.CutoutGeometricCount, (int) keyword, enable);
                }
            }
        }

        public static void GetKeyword(Material material, out EdgeBaseSource keyword)
        {
            keyword = (EdgeBaseSource) GetKeywordByMaterialVariable(material, (int) EnumID.EdgeBaseSource);
        }

        public static void SetKeyword(Material material, EdgeBaseSource keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.EdgeBaseSource, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, EdgeBaseSource keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.EdgeBaseSource, (int) keyword, enable);
                }
            }
        }

        public static void GetKeyword(Material material, out EdgeAdditionalColorSource keyword)
        {
            keyword = (EdgeAdditionalColorSource) GetKeywordByMaterialVariable(material, (int) EnumID.EdgeAdditionalColorSource);
        }

        public static void SetKeyword(Material material, EdgeAdditionalColorSource keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.EdgeAdditionalColorSource, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, EdgeAdditionalColorSource keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.EdgeAdditionalColorSource, (int) keyword, enable);
                }
            }
        }

        public static void GetKeyword(Material material, out EdgeUVDistortionSource keyword)
        {
            keyword = (EdgeUVDistortionSource) GetKeywordByMaterialVariable(material, (int) EnumID.EdgeUVDistortionSource);
        }

        public static void SetKeyword(Material material, EdgeUVDistortionSource keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.EdgeUVDistortionSource, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, EdgeUVDistortionSource keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.EdgeUVDistortionSource, (int) keyword, enable);
                }
            }
        }

        public static void GetKeyword(Material material, out GlobalControlID keyword)
        {
            keyword = (GlobalControlID) GetKeywordByMaterialVariable(material, (int) EnumID.GlobalControlID);
        }

        public static void SetKeyword(Material material, GlobalControlID keyword, bool enable)
        {
            SetKeyword(material, (int) EnumID.GlobalControlID, (int) keyword, enable);
        }

        public static void SetKeyword(Material[] materials, GlobalControlID keyword, bool enable)
        {
            if (materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    SetKeyword(materials[i], (int) EnumID.GlobalControlID, (int) keyword, enable);
                }
            }
        }


        public static string ToString(State keyword)
        {
            return enumNames[(int) EnumID.State][(int) keyword];
        }

        public static string ToString(CutoutStandardSource keyword)
        {
            return enumNames[(int) EnumID.CutoutStandardSource][(int) keyword];
        }

        public static string ToString(CutoutStandardSourceMapsMappingType keyword)
        {
            return enumNames[(int) EnumID.CutoutStandardSourceMapsMappingType][(int) keyword];
        }

        public static string ToString(CutoutGeometricType keyword)
        {
            return enumNames[(int) EnumID.CutoutGeometricType][(int) keyword];
        }

        public static string ToString(CutoutGeometricCount keyword)
        {
            return enumNames[(int) EnumID.CutoutGeometricCount][(int) keyword];
        }

        public static string ToString(EdgeBaseSource keyword)
        {
            return enumNames[(int) EnumID.EdgeBaseSource][(int) keyword];
        }

        public static string ToString(EdgeAdditionalColorSource keyword)
        {
            return enumNames[(int) EnumID.EdgeAdditionalColorSource][(int) keyword];
        }

        public static string ToString(EdgeUVDistortionSource keyword)
        {
            return enumNames[(int) EnumID.EdgeUVDistortionSource][(int) keyword];
        }

        public static string ToString(GlobalControlID keyword)
        {
            return enumNames[(int) EnumID.GlobalControlID][(int) keyword];
        }

        private static void SetKeyword(Material material, int enumID, int enumValue, bool enable)
        {
            if (material != null)
            {
                for (int i = 0; i < enumNames[enumID].Length; i++)
                {
                    material.DisableKeyword(enumNames[enumID][i]);
                }

                if (enable)
                {
                    material.EnableKeyword(enumNames[enumID][enumValue]);
                }


                material.SetInt(materialKeywordVariables[enumID], enumValue);
            }
        }

        private static int GetKeywordByMaterialVariable(Material material, int enumID)
        {
            if (material == null)
            {
                return 0;
            }

            return material.GetInt(materialKeywordVariables[enumID]);
        }
    }
}