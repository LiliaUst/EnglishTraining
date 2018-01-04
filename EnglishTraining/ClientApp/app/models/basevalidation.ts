export class BaseValidation {

    protected _success: boolean = true;
    get success(): boolean {
        for (var key in this) {
            if (key != '_success' && key != 'success' && typeof this[key] === 'boolean' && this[key]) {
                this._success = false;
                break;
            }
        }
        return this._success;
    }
    set success(value: boolean) {
        this._success = value;
    }
}