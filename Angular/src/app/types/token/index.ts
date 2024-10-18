//MyDemo.Client\src\app\core\jwt-token.ts

//import { capitalize, currentTimestamp } from "./util";

//MyDemo.Client\src\app\models\token.ts
export interface Token {
    //  [prop: string]: any;
    //the Jwt token return from API after login successfully
    access_token: string;
    // //the current user id
    // user_id?: string;
    // //should be just handle the 'Bearer' type in this sample
    // token_type?: string;
    // //How long will be the token expired(e.g. after 30 mins). This is a timestamp format
    expires_in?: number;
    // //the actually expire time, so should be the expires_in + current time, e.g. 
    // //if expires_in = 30 mins, then exp would be current time + 30 mins
    // exp?: number;
}

export function capitalize(text: string): string {
    return text.substring(0, 1).toUpperCase() + text.substring(1, text.length).toLowerCase();
}
/**
 * Get the current timestamp
 * @returns
 */
export function currentTimestamp(): number {
    return Math.ceil(new Date().getTime() / 1000);
}
/**
 * Filter the Non null object to make sure the object is valid
 * @param obj filter object
 * @returns
 */
export function filterObject<T extends Record<string, unknown>>(obj: T) {
    return Object.fromEntries(
        Object.entries(obj).filter(([, value]) => value !== undefined && value !== null)
    );
}

export class JwtToken {
    constructor(protected attributes: Token) { }
    get access_token(): string {
        return this.attributes.access_token;
    }
    // get user_id(): string {
    //     return this.attributes.user_id ?? '';
    // }
    // get token_type(): string {
    //     return this.attributes.token_type ?? 'Bearer';
    // }
    // get exp(): number | void {
    //     return this.attributes.exp;
    // }
    valid(): boolean {
        return this.hasAccessToken() && !this.isExpired();
    }
    getBearerToken(): string {
        return this.access_token
            ? [capitalize('Bearer'), this.access_token].join(' ').trim()
            : '';
    }
    private hasAccessToken(): boolean {
        return !!this.access_token;
    }
    /**
    Check the expired time
    Unit: seconds
    */
    private isExpired(): boolean {
        return false
        //  return this.exp !== undefined && this.exp - currentTimestamp() <= 0;
    }
}