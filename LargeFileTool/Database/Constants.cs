using System;
using System.Collections.Generic;
using System.Text;

namespace LargeFileTool.Database
{
    public struct AlleleVariantData
    {
        public const String ID = "id";
        public const String VARIANT = "variant";
        public const String COMPLEMENT = "complement";
        public const String TABLE = "allele_variant";
    }

    public struct BarCodeData
    {
        public const String BAR_CODE = "barcode";
        public const String BAR_CODE_COLUMN = "code";
        public const String CODE_LENGTH = "code_length";
        public const String IDENTIFIABLE_ID = "identifiable_id";
        public const String KIND = "kind";
        public const String TABLE_EXTERNAL = "external_barcode";
        public const String TABLE_INTERNAL = "internal_barcode";
    }

    public struct ContainerData
    {
        public const String ACTIVE_CONTAINERS = "active_containers";
        public const String BAR_CODE = "barcode";
        public const String BAR_CODE_LENGTH = "barcode_length";
        public const String COMMENT = "comment";
        public const String CONTAINER_ID = "id";
        public const String EXTERNAL_BAR_CODE = "external_barcode";
        public const String IDENTIFIABLE_ID = "identifiable_id";
        public const String IDENTIFIER = "identifier";
        public const String IDENTIFIER_FILTER = "identifier_filter";
        public const String SIZE_X = "size_x";
        public const String SIZE_Y = "size_y";
        public const String SIZE_Z = "size_z";
        public const String STATUS = "status";
        public const String STATUS_CHANGED = "status_changed";
        public const String TABLE = "container";
        public const String TO_CONTAINER_ID = "to_container_id";
        public const String TYPE = "type";
        public const String AUTHORITY_ID = "authority_id";
    }

    public struct DataCommentData
    {
        public const String COMMENT = "comment";
    }

    public struct DataIdentifierData
    {
        public const String IDENTIFIER = "identifier";
    }
    public struct DataIdentityData
    {
        public const String ID = "id";
    }

    public struct GenericContainerData
    {
        public const String ACTIVE_CONTAINERS = "active_containers";
        public const String BAR_CODE = "barcode";
        public const String COMMENT = "comment";
        public const String GENERIC_CONTAINER_ID = "id";
        public const String IDENTIFIER = "identifier";
        public const String IDENTIFIER_FILTER = "identifier_filter";
        public const String STATUS = "status";
        public const String TABLE = "all_containers";
    }

    public struct UserData
    {
        public const String ACCOUNT_STATUS = "account_status";
        public const String COMMENT = "comment";
        public const String IDENTIFIER = "identifier";
        public const String NAME = "name";
        public const String TABLE = "authority";
        public const String USER_ID = "id";
        public const String USER_TYPE = "user_type";
        public const String BAR_CODE = "barcode";
    }

}
