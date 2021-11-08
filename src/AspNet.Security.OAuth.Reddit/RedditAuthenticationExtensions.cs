﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using AspNet.Security.OAuth.Reddit;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods to add Reddit authentication capabilities to an HTTP application pipeline.
/// </summary>
public static class RedditAuthenticationExtensions
{
    /// <summary>
    /// Adds <see cref="RedditAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables Reddit authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static AuthenticationBuilder AddReddit([NotNull] this AuthenticationBuilder builder)
    {
        return builder.AddReddit(RedditAuthenticationDefaults.AuthenticationScheme, options => { });
    }

    /// <summary>
    /// Adds <see cref="RedditAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables Reddit authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="configuration">The delegate used to configure the OpenID 2.0 options.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static AuthenticationBuilder AddReddit(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] Action<RedditAuthenticationOptions> configuration)
    {
        return builder.AddReddit(RedditAuthenticationDefaults.AuthenticationScheme, configuration);
    }

    /// <summary>
    /// Adds <see cref="RedditAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables Reddit authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="scheme">The authentication scheme associated with this instance.</param>
    /// <param name="configuration">The delegate used to configure the Reddit options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddReddit(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] string scheme,
        [NotNull] Action<RedditAuthenticationOptions> configuration)
    {
        return builder.AddReddit(scheme, RedditAuthenticationDefaults.DisplayName, configuration);
    }

    /// <summary>
    /// Adds <see cref="RedditAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables Reddit authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="scheme">The authentication scheme associated with this instance.</param>
    /// <param name="caption">The optional display name associated with this instance.</param>
    /// <param name="configuration">The delegate used to configure the Reddit options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddReddit(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] string scheme,
        [CanBeNull] string caption,
        [NotNull] Action<RedditAuthenticationOptions> configuration)
    {
        return builder.AddOAuth<RedditAuthenticationOptions, RedditAuthenticationHandler>(scheme, caption, configuration);
    }
}
