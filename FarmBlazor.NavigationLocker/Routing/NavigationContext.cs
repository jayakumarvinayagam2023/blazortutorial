namespace FarmBlazor.NavigationLocker
{
    public sealed class NavigationContext
    {
        public NavigationContext(string path, CancellationToken cancellationToken)
        {
            Path = path;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// The target path for the navigation.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// The <see cref="CancellationToken"/> to use to cancel navigation.
        /// </summary>
        public CancellationToken CancellationToken { get; }
    }
}
