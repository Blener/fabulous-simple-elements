﻿[<RequireQualifiedAccess>]
module Label  
    
open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets
open Xamarin.Forms

type ILabelProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new ILabelProp with 
        member x.name = name 
        member x.value = value }    

// === Label Specific === 
let Text (text: string) = createProp "text" text 
let LineBreakMode (mode: LineBreakMode) = createProp "lineBreakMode" mode

let TextColor (color: Color) = createProp "textColor" color 
let FontSize ((FontSize.FontSize size): FontSize.IFontSize) = createProp "fontSize" size 
let FontSizeInPixels (fontSize: double) = createProp "fontSize" fontSize
let FontAttributes (attributes: FontAttributes) = createProp "fontAttributes" attributes
let FontFamily (fontFamily: string) = createProp "fontFamily" fontFamily
// === Label Specific ===

// Common attributes
let HorizontalTextAlignment (alignment: TextAlignment) = createProp "horizontalTextAlignment" alignment
let VerticalTextAlignment (alignment: TextAlignment) = createProp "verticalTextAlignment" alignment
let GestureRecognizers (elements: ViewElement list) = createProp "gestureRecognizers" elements 
let HorizontalLayout (options: LayoutOptions) = createProp "horizontalOptions" (box options)
let IsEnabled (condition: bool) = createProp "isEnabled" condition
let IsVisible (condition: bool) = createProp "isVisible" condition
let AnchorY (value: double) = createProp "anchorY" value 
let BackgroundColor (color: Color) = createProp "backgroundColor" color
let AnchorX (value: double) = createProp "anchorX" value 
let Scale (value: double) = createProp "scale" value 
let Rotation (value: double) = createProp "rotation" value 
let RotationX (value: double) = createProp "rotationX" value 
let RotationY (value: double) = createProp "rotationY" value 
let TranslationX (value: double) = createProp "translationX" value 
let TranslationY (value: double) = createProp "translationY" value
let Opacity (value: double) = createProp "opacity" value
let Height (value: double) = createProp "heightRequest" value 
let MinimumHeight (value: double) = createProp "minimumHeightRequest" value 
let MinimumWidth (value: double) = createProp "minimumWidthRequest" value 
let Width (value: double) = createProp "widthRequest" value
let Style (style: Style) = createProp "style" style 
let StyleSheets (sheets: StyleSheet list) = createProp "styleSheets" sheets
let StyleId (id: string) = createProp "styleId" id
let ClassId (id: string) = createProp "classId" id 
let Ref (viewRef: ViewRef<Label>) = createProp "ref" viewRef  
let AutomationId (id: string) = createProp "automationId" id
let Resources (values: (string * obj) list) = createProp "resources" values 
let InputTransparent (condition: bool) = createProp "inputTransparent" condition 
let FormattedText (element: ViewElement) = createProp "formattedText" element
let Margin (value: double) = createProp "margin" (Thickness(value)) 
let MarginLeft (value: double) = createProp "marginLeft" value 
let MarginRight (value: double) = createProp "marginRight" value 
let MarginTop (value: double) = createProp "marginTop" value 
let MarginBottom (value: double) = createProp "marginBottom" value 
let MarginThickness (thickness: Thickness) = createProp "margin" thickness 
// === Grid definitions ===
let GridRow (n: int) = createProp "gridRow" n 
let GridColumn (n: int) = createProp "gridColumn" n 
let GridRowSpan (n: int) = createProp "gridRowSpan" n
let GridColumnSpan (n: int) = createProp "gridColumnSpan" n
// === Grid definitions ===

// === FlexLayout definitions ===
let FlexOrder (n: int) = createProp "flexOrder" n
let FlexGrow (value: double) = createProp "flexGrow" value
let FlexShrink (value: double) = createProp "flexShrink" value
let FlexAignSelf (value: FlexAlignSelf) = createProp "flexAlignSelf" value
let FlexLayoutDirection (value: FlexDirection) = createProp "flexLayoutDirection" value
let FlexBasis (value: FlexBasis) = createProp "flexBasis" value
// === FlexLayout definitions ===

let TextDecorations (decorations: TextDecorations) = createProp "textDecorations" decorations 

let OnCreated (f: Label -> unit) = createProp "created" f

let label (props: ILabelProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.Label(?text = find "text",
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?verticalTextAlignment = find "verticalTextAlignment",
        ?horizontalTextAlignment = find "horizontalTextAlignment",
        ?lineBreakMode = find "lineBreakMode",
        ?formattedText = find "formattedText",
        ?isEnabled = find "isEnabled",
        ?isVisible = find "isVisible",
        ?textColor = find "textColor",
        ?textDecorations=find"textDecorations",
        ?ref = find "ref",
        ?created = find "created",
        ?verticalOptions = find "verticalOptions",
        ?opacity = find "opacity",
        ?heightRequest = find "heightRequest",
        ?widthRequest = find "widthRequest",
        ?anchorX = find "anchorX", 
        ?anchorY = find "anchorY", 
        ?scale = find "scale", 
        ?rotation = find "rotation",
        ?rotationX = find "rotationX",
        ?rotationY = find "rotationY",
        ?translationX = find "translationX",
        ?translationY = find "translationY",
        ?style = find "style", 
        ?styleSheets = find "styleSheets",
        ?styleId = find "styleId",
        ?gestureRecognizers = find "gestureRecognizers",
        ?fontAttributes = find "fontAttributes",
        ?classId = find "classId",
        ?automationId = find "automationId",
        ?resources = find "resources",
        ?minimumHeightRequest = find "minimumHeightRequest",
        ?minimumWidthRequest = find "minimumHeightRequest",
        ?fontFamily = find "fontFamily",
        ?fontSize = find "fontSize",
        ?backgroundColor = find "backgroundColor",
        ?inputTransparent = find "inputTransparent",
        ?horizontalOptions = find "horizontalOptions")

    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes