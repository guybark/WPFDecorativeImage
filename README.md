# WPFDecorativeImage
This WPF demo app shows how to prevent Narrator reaching images that are purely decorative.

The XAML contains two images. The first image contains information important to the customer, and so the image is given a name that gets exposed through the UI Automation (UIA) Name property. In this case the image is also given supplemental information describing the image, which gets exposed through the UIA HelpText property. Note that while the full description is exposed through UIA, the Narrator screen reader chooses not to speak it all.

Important: The demo app does not localize the Name or HelpText. A shipping app would localize these.

The second image in the demo app is purely decorative, and shows no information of interest to customers. As such, if Narrator were to move to it, that would be an unhelpful distraction to the customer. As such the app takes action to inform screen readers that the image is not of interest to customers. It does this by removing the image from the Control view of the UIA tree. UI elements that are not exposed through the Control view of the UIA tree are consider not interesting to customers.
