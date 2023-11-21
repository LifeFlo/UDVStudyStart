declare module "*.module.css" {
    const content: Record<string, string>;
    export default content;
}

type Todo = {
    id: number;
    name: string;
    description: string;
    checked: boolean;
};
