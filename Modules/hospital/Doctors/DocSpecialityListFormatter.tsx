import { Decorators, Formatter, Lookup } from "@serenity-is/corelib";
import { FormatterContext } from "@serenity-is/sleekgrid";
import { SpecialityRow } from "../../ServerTypes/hospital";

let lookup: Lookup<SpecialityRow>;
let promise: Promise<Lookup<SpecialityRow>>;

@Decorators.registerFormatter('hospital.SpecialityListFormatter')
export class DocSpecialityListFormatter implements Formatter {

    format(ctx: FormatterContext) {

        let idList = ctx.value as number[];
        if (!idList || !idList.length)
            return "";

        let byId = lookup?.itemById;
        if (byId) {
            return idList.map(id => {
                var specialty = byId[id];
                return ctx.escape(specialty == null ? id : specialty.SpecialityName);
            }).join(", ");
        }

        promise ??= SpecialityRow.getLookupAsync().then(l => {
            lookup = l;
            try {
                ctx.grid?.invalidate();
            }
            finally {
                lookup = null;
                promise = null;
            }
        }).catch(() => promise = null);

        return <i class="fa fa-spinner" > </i>;
    }
}