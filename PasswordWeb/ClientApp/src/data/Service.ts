    export class Service
    {
       constructor() {
            this.Name = "";
            this.Size = 15;
            this.IncludeEspecialChar = true;
            this.IncludeNumbers = true;
            this.IncludeUpperLower = true;
            this.OnlyNumbers = false;
        }

        Name: String;
        Size: number;
        IncludeEspecialChar: boolean; 
        IncludeNumbers: boolean; 
        IncludeUpperLower: boolean; 
        OnlyNumbers: boolean; 
    }