namespace UtilityHelper.Infostruct
{
    public enum FileContentType
    {
        [TitleAtribute("AAC audio", Caption = "audio/aac")]
        aac,
        [TitleAtribute("AbiWord document", Caption = "application/x-abiword")]
        abw,
        [TitleAtribute("Archive document (multiple files embedded)", Caption = "application/x-freearc")]
        arc,
        [TitleAtribute("AVI: Audio Video Interleave", Caption = "video/x-msvideo")]
        avi,
        [TitleAtribute("Amazon Kindle eBook format", Caption = "application/vnd.amazon.ebook")]
        azw,
        [TitleAtribute("Any kind of binary data", Caption = "application/octet-stream")] 
        bin,
        [TitleAtribute("Windows OS/2 Bitmap Graphics", Caption = "image/bmp")] 
        bmp,
        [TitleAtribute("BZip archive", Caption = "application/x-bzip")] 
        bz, 
        [TitleAtribute("BZip2 archive", Caption = "application/x-bzip2")] 
        bz2, 
        [TitleAtribute("C-Shell script", Caption = "application/x-csh")] 
        csh, 
        [TitleAtribute("Cascading Style Sheets (CSS)", Caption = "text/css")] 
        css, 
        [TitleAtribute("Comma-separated values (CSV)", Caption = "text/csv")] 
        csv,
        [TitleAtribute("Microsoft Word", Caption = "application/msword")] 
        doc, 
        [TitleAtribute("Microsoft Word (OpenXML)", Caption = "application/vnd.openxmlformats-officedocument.wordprocessingml.document")] 
        docx, 
        [TitleAtribute("MS Embedded OpenType fonts", Caption = "application/vnd.ms-fontobject")] 
        eot, 
        [TitleAtribute("Electronic publication (EPUB)", Caption = "application/epub+zip")] 
        epub, 
        [TitleAtribute("GZip Compressed Archive", Caption = "application/gzip")] 
        gz, 
        [TitleAtribute("Graphics Interchange Format (GIF)", Caption = "image/gif")] 
        gif, 
        [TitleAtribute("HyperText Markup Language (HTML)", Caption = "text/html")] 
        htm, 
        [TitleAtribute("HyperText Markup Language (HTML)", Caption = "text/html")] 
        html, 
        [TitleAtribute("Icon format", Caption = "image/vnd.microsoft.icon")]
        ico, 
        [TitleAtribute("iCalendar format", Caption = "text/calendar")] 
        ics, 
        [TitleAtribute("Java Archive (JAR)", Caption = "application/java-archive")] 
        jar, 
        [TitleAtribute("JPEG images", Caption = "image/jpeg")] 
        jpeg, 
        [TitleAtribute("JavaScript", Caption = "text/javascript")] 
        js, 
        [TitleAtribute("JSON format", Caption = "application/json")] 
        json, 
        [TitleAtribute("JSON-LD format", Caption = "application/ld+json")] 
        jsonld, 
        [TitleAtribute("Musical Instrument Digital Interface (MIDI)", Caption = "audio/midi audio/x-midi")] 
        mid, 
        [TitleAtribute("JavaScript module", Caption = "text/javascript")] 
        mjs, 
        [TitleAtribute("MP3 audio", Caption = "audio/mpeg")] 
        mp3,
        [TitleAtribute("MPEG Video", Caption = "video/mpeg")] 
        mpeg, 
        [TitleAtribute("Apple Installer Package", Caption = "application/vnd.apple.installer+xml")] 
        mpkg, 
        [TitleAtribute("OpenDocument presentation document", Caption = "application/vnd.oasis.opendocument.presentation")] 
        odp, 
        [TitleAtribute("OpenDocument spreadsheet document", Caption = "application/vnd.oasis.opendocument.spreadsheet")] 
        ods, 
        [TitleAtribute("OpenDocument text document", Caption = "application/vnd.oasis.opendocument.text")] 
        odt, 
        [TitleAtribute("OGG audio", Caption = "audio/ogg")] 
        oga, 
        [TitleAtribute("OGG video", Caption = "video/ogg")] 
        ogv, 
        [TitleAtribute("OGG", Caption = "application/ogg")] 
        ogx, 
        [TitleAtribute("OpenType font", Caption = "font/otf")] 
        otf, 
        [TitleAtribute("Portable Network Graphics", Caption = "image/png")] 
        png, 
        [TitleAtribute("Adobe Portable Document Format (PDF)", Caption = "application/pdf")] 
        pdf, 
        [TitleAtribute("Hypertext Preprocessor (Personal Home Page)", Caption = "appliction/php")] 
        php, 
        [TitleAtribute("Microsoft PowerPoint", Caption = "application/vnd.ms-powerpoint")] 
        ppt, 
        [TitleAtribute("Microsoft PowerPoint (OpenXML)", Caption = "application/vnd.openxmlformats-officedocument.presentationml.presentation")] 
        pptx, 
        [TitleAtribute("RAR archive", Caption = "application/x-rar-compressed")] 
        rar, 
        [TitleAtribute("Rich Text Format (RTF)", Caption = "application/rtf")] 
        rtf, 
        [TitleAtribute("Bourne shell script", Caption = "application/x-sh")] 
        sh, 
        [TitleAtribute("Scalable Vector Graphics (SVG)", Caption = "image/svg+xml")] 
        svg, 
        [TitleAtribute("Small web format (SWF) or Adobe Flash document", Caption = "application/x-shockwave-flash")]
        swf, 
        [TitleAtribute("Tape Archive (TAR)", Caption = "application/x-tar")] 
        tar, 
        [TitleAtribute("Tagged Image File Format (TIFF)", Caption = "image/tiff")] 
        tif, 
        [TitleAtribute("Tagged Image File Format (TIFF)", Caption = "")] 
        tiff, 
        [TitleAtribute("MPEG transport stream", Caption = "video/mp2t")]
        ts, 
        [TitleAtribute("TrueType Font", Caption = "font/ttf")] 
        ttf, 
        [TitleAtribute("Text, (generally ASCII or ISO 8859-n)", Caption = "text/plain")] 
        txt, 
        [TitleAtribute("Microsoft Visio", Caption = "application/vnd.visio")] 
        vsd, 
        [TitleAtribute("Waveform Audio Format", Caption = "audio/wav")] 
        wav, 
        [TitleAtribute("WEBM audio", Caption = "audio/webm")] 
        weba, 
        [TitleAtribute("WEBM video", Caption = "video/webm")] 
        webm, 
        [TitleAtribute("WEBP image", Caption = "image/webp")] 
        webp, 
        [TitleAtribute("Web Open Font Format (WOFF)", Caption = "font/woff")] 
        woff, 
        [TitleAtribute("Web Open Font Format (WOFF)", Caption = "font/woff2")] 
        woff2, 
        [TitleAtribute("XHTML", Caption = "application/xhtml+xml")] 
        xhtml, 
        [TitleAtribute("Microsoft Excel", Caption = "application/vnd.ms-excel")] 
        xls, 
        [TitleAtribute("Microsoft Excel (OpenXML)", Caption = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        xlsx, 
        [TitleAtribute("XML", Caption = "application/xml if not readable from casual users (RFC 3023, section 3)")] 
        xml, 
        [TitleAtribute("XML", Caption = "text/xml if readable from casual users (RFC 3023, section 3)")] 
        xmlif, 
        [TitleAtribute("XUL", Caption = "application/vnd.mozilla.xul+xml")]
        xul, 
        [TitleAtribute("ZIP archive", Caption = "application/zip")] 
        zip,
        [TitleAtribute("3GPP audio/video container", Caption = "video/3gpp")] 
        e3gp, 
        [TitleAtribute("3GPP audio/video container", Caption = "audio /3gpp if it doesn't contain video")] 
        e3gpif, 
        [TitleAtribute("3GPP2 audio/video container", Caption = "video/3gpp2")] 
        e3g2, 
        [TitleAtribute("3GPP2 audio/video container", Caption = "audio/3gpp2 if it doesn't contain video")] 
        e3gif, 
        [TitleAtribute("7-zip archive", Caption = "application/x-7z-compressed")]
        e7z
    }

}
