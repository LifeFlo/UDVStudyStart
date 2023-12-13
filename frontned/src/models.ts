export interface IProduct{
    title: string
    discription: string
}

export  interface ITask{
    title: string,
    discription: string,
}

export  interface IEmplHR{
    fio: string
    mail: string
    doCheck: number
}

export interface IEmploye{
    value: {
        name: string,
        surname: string,
        middleName: string,
        email: string
    },
    error: null,
    errorExplain: null
}

export interface IGame{
    planet: string,
    description: string
}

