namespace Movies.Api;

public static class ApiEndpoints {
    private const string ApiBase = "api";

    public static class Recipes {
        private const string Base = $"{ApiBase}/recipes";
        
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";

    }

    public static class Tags {
        private const string Base = $"{ApiBase}/tags";
        
        public const string GetAll = Base;
    }

    public static class Groceries {
        private const string Base = $"{ApiBase}/groceries";
        
        public const string Create = Base;
        public const string GetAll = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
    }
    
    public static class Pantry {
        private const string Base = $"{ApiBase}/pantry";
        
        public const string Create = Base;
        public const string GetAll = Base;
        public const string Update = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
    }
}