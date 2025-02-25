import { Decorators } from "@serenity-is/corelib";

export enum GenderEnum {
    Male = 1,
    Female = 2
}
Decorators.registerEnumType(GenderEnum, 'Serene2.Modules.hospital.Patients.Enum.GenderEnum', 'Gender');