export interface IProduct{
    title: string
    discription: string
}

export  interface ITask{
    value:
        {
            id: string,
            title: string,
            desc: string,
            accountId: string,
            isComplete: boolean,
            date: string
        }[]

}

export  interface IEmplHR{
    value: {
        id: string,
        name: string,
        surname: string,
        middleName: string,
        email: string,
        completeStep: number,
        totalStep: number
    }[]
}

export interface IGame{
    planet: string,
    description: string
}

