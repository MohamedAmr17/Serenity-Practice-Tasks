import { Decorators } from "@serenity-is/corelib";

export enum TypeEnum {
    type1 = 1,
    type2 = 2
}
Decorators.registerEnumType(TypeEnum, 'Serene2.Modules.hospital.Patients.Enum.TypeEnum', 'Type');