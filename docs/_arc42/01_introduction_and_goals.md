Einführung und Ziele {#section-introduction-and-goals}
====================

In diesem Dokument geht es um die Ausarbeitung des T4 FileManagers, der als Hilfe für die Code Generierung mit T4 Text Templates dient. Dieser Manager soll eine wichtige Grundlage für unsere Building Blocks liefern, damit gewisse Prozesse optimiert und automatisiert werden können.

Aufgabenstellung {#_aufgabenstellung}
----------------

Alle Aufgaben sind im Feature definiert: [Feature Code Generierung](https://dev.azure.com/databinding/Building%20Blocks/_workitems/edit/4).

Qualitätsziele {#_qualit_tsziele}
--------------

| Qualitätsmerkmal                                             | Motivation und Erläuterung                                   |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| Einfache Anwendung (Analysierbarkeit)                        | Ein Entwickler kann den T4 FileManager einfach verstehen und benützen. |
| Schnelle und sichere Generierung der Files (Fehlertoleranz)  | Ein Entwickler kann den T4 FileManager bei richtiger Anwendung effizient und fehlerfrei anwenden. |
| Kann für das alte als auch neue Visual Studio genutzt werden (Attraktivität) | Ein Entwickler soll diesen  Manager sowohl für .NET Standard, .NET Core als auch für das .NET Framework  einsetzten können. |
| Jegliche Art von Dateien können generiert werden (Attraktivität) | Ein Entwickler kann  jegliche Arten von Dateien generieren (egal ob C#, Textfiles, SQL oder  weiteres). |

