namespace MissYou

type MissDetails =
    { Title: string option
      FaviconHref: string option }

[<RequireQualifiedAccess>]
module Miss =

    open Browser.Dom
    open Browser.Types
    open Fable.Core.JsInterop

    type private MissSettings =
        { Favicon: Element
          DocumentTitle: string
          FaviconHref: string }

    let private onVisibilityChanged (details: MissDetails) (settings: MissSettings) =
        if details.Title.IsSome then
            document.title <- if document.hidden then details.Title.Value else settings.DocumentTitle
        if details.FaviconHref.IsSome then
            let iconSrc = if document.hidden then details.FaviconHref.Value else settings.FaviconHref
            settings.Favicon.setAttribute ("href", iconSrc)

    let register (details: MissDetails) =
        if details.Title.IsSome || details.FaviconHref.IsSome then
            let favicon = document.querySelector "link[rel$=\"icon\"]"
            let settings =
                { Favicon = favicon
                  DocumentTitle = document.title
                  FaviconHref = favicon?href }
            let visibilityChanged _ = onVisibilityChanged details settings
            document.addEventListener ("visibilitychange", visibilityChanged)