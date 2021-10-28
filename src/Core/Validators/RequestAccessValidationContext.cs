namespace Nova.Common.Validators
{
    public record RequestAccessValidationContext
    {
        readonly HashSet<string> _succeededPermissions = new();
        readonly HashSet<string> _failedPermissions = new();

        public IEnumerable<string> SucceededPermissions => _succeededPermissions;
        public IEnumerable<string> FailedPermissions => _failedPermissions;

        public RequestAccessValidationResult Result 
        {
            get
            {
                if (_failedPermissions.Count > 0)
                    return RequestAccessValidationResult.Failed;

                if (_succeededPermissions.Count > 0)
                    return RequestAccessValidationResult.Succeeded;

                return RequestAccessValidationResult.NoValidationChecked;
            }
        }

        public void Succeed(string permission)
        {
            _succeededPermissions.Add(permission);
        }
        
        public void Fail(string permission)
        {
            _failedPermissions.Add(permission);
        }
    }    
}