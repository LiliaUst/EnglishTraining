
export class Verb {
    id?: number;
    infinitiveEn: string;
    infinitiveRu: string;
    isIrregular: boolean;

    isFull: boolean;

    personVerbsToVerbs: PersonVerbsToVerbs[] = [];

    verbForms: any = {};
}

export class PersonVerbsToVerbs {
    id?: number;
    tenseVerbId: number;
    numberVerbId: number;
    personVerbId: number;
    verbId: number;
    verbEn: string;
    verbRu: string;
}

export enum TenseVerbs {
    PresentSimple = 1
}

export enum PersonVerbs {
    First = 1,
    Second = 2,
    Third = 3
}

export enum NumberVerbs {
    Singular = 1,
    Plural = 2
}