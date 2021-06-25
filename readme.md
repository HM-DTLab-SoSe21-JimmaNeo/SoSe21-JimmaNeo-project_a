# Team aLive

Als Team möchten wir uns nochmals bei den Auftraggebern Victoria Lieftüchter und Dr. Tobais Reicherzer für die Möglichkeit bedanken an diesem Projekt teilzunehmen. Ein weiterer Dank geht an Lars Schmitz für die Unterstützung im Projekt.

Wir hoffen wir haben es durch unseren Prototypen geschafft, dass Projekt voranzutreiben und richtige Impulse zu setzten. 




# PressRelease

Heute hat aLive Inc. eine E-Learning Plattform angekündigt, welche die Zusammenarbeit äthiopischer und deutscher Neonatologen vereinfacht. Der Fokus liegt hierbei vor allem darauf, Behandlungsmöglichkeiten und die Versorgung von Neugeborenen zu verbessern.

Angetrieben durch das Motto „Leben zu retten“ ist es den Ärzten aus München durch die Corona-Pandemie verwehrt Schulungen und Trainings in Äthiopien zu begleiten, ohne das Leben anderer zu gefährden. Dazu sagte Dr. med. Tobias Reicherzer Facharzt für Kinder- und Jugendmedizin, Neonatologe und Funktionsoberarzt des LMU Klinikums:

> „Schade, dass die Schulungen in Jimma derzeit nicht stattfinden können. Es wäre toll, wenn es eine Alternative darfür geben würde.“

Die Plattform aLive soll dafür einen adäquaten Ersatz bieten. Unterschiedlichste Gamification-Lösungen schaffen in einer Learning-Path Roadmap bestehend aus Lerneinheiten ein motivierendes Umfeld. Durch die Kombination von Präsentationsmöglichkeiten (Frage-Antwort-Schemata, Fallstudien und Videocontent) wird das medizinische Personal in Äthiopien gezielt an Themenschwerpunkte herangeführt, welche dann mit Hilfe von Online-Sessions abgerundet werden.

aLive hat das Ziel in einem effizienten, aber auch unterhaltsamen Umfeld Wissen zu vermittelten. Hierbei setzen wir auf den Cross-Learning-Effekt und das Durchbrechen klassischen Lehrer-Schüler-Strukturen. Indem wir dem medizinischen Fachpersonal aus Äthiopien die Möglichkeit bieten, dass in der Plattform angesiedelte Wissen zu erweitern beziehungsweise den generierten Content gezielt zu steuern. Erreicht wird dies durch eine Feedback Funktion.

Für Nutzer dient aLive dazu, Methoden zur Behandlung der Neugeborenen zu verbessern, aber auch diese Methoden auf die aktuellen Gegebenheiten anzupassen. Ärzte in Äthiopien können Feedback geben, falls die gezeigten Methoden mit dem dort befindlichen Equipment nicht durchführbar sind und schaffen zusammen mit den Ärzten in München adaptierte Lösungen.

Umgesetzt wird das Projekt mittels einer webbasierten Plattformlösung, welche auf allen internetfähigen Endgeräten zugänglich sein wird. Potentiellen Nutzern ist es möglich Lerninhalte herunterzuladen wodurch eine zuverlässige Nutzung gewährleistet wird.

# Anwendungsbeschreibung

## Sidebar

<details><summary>Click to expand</summary>

![](/documentation/Screenshots/Bildschirmfoto_2021-06-24_um_17.12.18.png)

</details>

## Mainpage

Die Mainpage ist das Herzstück unserer Anwendung. Hier können Nutzer die Kursübersicht und den Fortschritt bei den jeweiligen Kursen einsehen.

Außerdem werden hier die Kurse absolviert. Nutzer können sich durch Videos, Beschreibungen, PFS's über ein Thema informieren. Hat ein User das Gefühl er hat den Kursinhalt verstanden, kann er das dazugehörige Quiz absolvieren um seinen Wissenstand zu überprüfen. 

<details><summary>Click to expand</summary>

![](/documentation/Screenshots/mainpage_alive.PNG)

</details>

<details><summary>Click to expand</summary>

![](/documentation/Screenshots/Bildschirmfoto_2021-06-24_um_17.54.53.png)

</details>

## Hilfe Funktion

Im Hilfemenü können Nutzer die FAQ's einsehen um Fragen zur Anwendung und ihrem Umfeld effektiv beantworten zu können.

<details><summary>Click to expand</summary>

![](/documentation/Screenshots/Bildschirmfoto_2021-06-24_um_17.27.12.png)

</details>

## Feedback Funktion

Die Feedback-Funktion ist unser **Kernfeature**. Ziel war es einen Cross-Learning-Effekt zu erreichen um klassische Lehrer-Schüler Strukturen zu durchbrechen um lernen auf Augenhöhe zu garantieren. Das erreichen wir, indem wir dem medizinischen Fachpersonal aus Äthiopien die Möglichkeit bieten, dass in der Plattform angesiedelte Wissen zu erweitern und den generierten Content gezielt zu steuern. 

<details><summary>Click to expand</summary>

![](/documentation/Screenshots/Bildschirmfoto_2021-06-24_um_17.28.25.png)

</details>

Administratoren können die abgegebenen Feedbacks abrufen um so Fragen zu beantworten oder Mängel zu beseitigen. Sollten mehrere Feedbacks zum gleichen Themengebiet auftreten können die Administraoren Course erweitern oder Fragen direkt in ein Quiz einbauen.

## Edit Quiz Funktion

In der Edit Quiz Funktion, kann der Administrator Multiple- oder Singlechoice-Quize erstellen. Es ist möglich die Fragen und Antworten hinzuzufügen und wieder zu löschen. Antwortmöglichkeiten können anschließend noch in ihren Wahrheitswert definiert werden. Die Anzahl der Quiz, Fragen und Antwortmöglichkeiten ist variabel und kann ebenfalls vom Administrator bearbeitet werden.

## Edit Course Funktion

Administratoren können in unserer Webanwendung Kurse erstellen, bearbeiten und löschen. Bei der Erstellung und Bearbeitung können:

- Kursname
- Kursbeschreibung
- ein Bild
- Videos
- PDF's
- und ein Quiz

an das System übergeben werden. Hierbei ist zu beachten, dass sowohl Bilder wie auch Videos per URL aufgerufen werden müssen. Anwender können den Kurs direkt nach der Erstellung abrufen.

<details><summary>Click to expand</summary>

![](/documentation/Screenshots/Bildschirmfoto_2021-06-24_um_16.49.12.png)

</details>

## Newsletter

Den Newsletter haben wir eingeführt um die User über neuen Content zu informieren. Zu einem spätern Entwicklungszeitpunkt können User so über neue Kurinhalte, per Email, benachrichtigt werden. Das Newsletter-Template ist Cross-Client kompatibel und bietet somit eine optimale Darstellung über die gängigen Email-Clients.

<details><summary>Click to expand</summary>

![](/documentation/Screenshots/Bildschirmfoto_2021-06-24_um_16.28.30.png)

</details>

# Softwarearchitektur

Allgemein handelt es sich um eine Blazer Single Page Applikation (SPA).
Die Anwendung setzt sich aus zwei unabhängigen Schichten zusammen, einerseits das Frontend, welches als Webanwendung bereitgestellt wird, andererseits das serverseitige Backend. 
Das Zusammenspiel der beiden Schichten basiert auf der REST-API Technologie.

**Frontend:**

Hier werden Razorkomponenten verwendet, um einen dynamischen HTML-Code zu generieren. Um eine ansprechende Optik zu gewährleisten, wurde auf Bootstrap zurückgegriffen. Zusätzlich wurden interaktive Elemente mittels C#, aber auch JavaScript umgesetzt.

**Backend:**

Der Sourcecode ist in C# geschrieben worden. Des weiteren sind Datenbankzugriffe möglich, wobei das C#-Framework LINQ die Geschäftslogik übernimmt.





# Team und Ansprechpartner

**Team:**

| Name | Surname |
| ------ | ------ |
| Afonin | Alexander |
| Davlatova | Muharram |
| Kallmaier | Christian |
| Passon | Valentin |
| Speidel | Maximilian |
| Quynh | Chi Lai |		 			
     		
**Ansprechpartner:**

| Name | Surname | Email |
| ------ | ------ | ------ |
| Kallmaier | Christian | c.kallmaier@hm.edu |

# Anlagen

### PressRelease

https://gitlab.lrz.de/seii_sose_2021/project_a/-/blob/master/documentation/LMU_TEAM_A_PR_Version_1.2.pdf

### FAQ's

https://gitlab.lrz.de/seii_sose_2021/project_a/-/blob/master/documentation/FAQ_Team_a_aLive.pdf

### Storyboard

https://gitlab.lrz.de/-/ide/project/seii_sose_2021/project_a/edit/master/-/documentation/storyboard.jpg
