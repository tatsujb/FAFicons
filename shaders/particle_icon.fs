#version 140

// particle_icon.fs

#ifdef GL_ES
precision mediump float;
#endif

uniform sampler2D Texture;

in vec2 v_TexCoord;
in vec4 v_ColorPrimary;
in vec4 v_ColorSecondary;
in float v_SelectedState;

out vec4 out_FragColor;

// lightness calculation.
float getLuma (in vec3 col)
    { return ( 0.3*col.r+0.59*col.g+0.11*col.b ); }

// blending.
// arguments: input colour, and blending colours (edges of RGB cube)
// i.e. col000 corresponds to what the black pixels turn into,
// col100 what the red pixels turn into, col101 the magenta pixels, etc...
// this function turns the input colour into a blend of the given colours
vec4 combo(in vec3 col,    in vec4 col000, in vec4 col111,
           in vec4 col100, in vec4 col010, in vec4 col001,
           in vec4 col110, in vec4 col101, in vec4 col011)
    {
    vec3 loc = vec3(1.0,1.0,1.0) - col;
    return ( col.x*col.y*col.z*col111 + col.x*col.y*loc.z*col110
           + col.x*loc.y*col.z*col101 + col.x*loc.y*loc.z*col100
           + loc.x*col.y*col.z*col011 + loc.x*col.y*loc.z*col010
           + loc.x*loc.y*col.z*col001 + loc.x*loc.y*loc.z*col000
           );
	//	  bool isClose (in vec3 col1, in vec3 col2)
    //{ return (((col1.r-col2.r)^2 + (col1.g-col2.g)^2 + (col1.b-col2.b)^2) < 0.05);}
    }


<<<<<<< HEAD
vec4 Drey = vec4(0.1,0.1,0.1,1.0);
vec4 Grey = vec4(0.69,0.69,0.69,1.0);
vec4 Green = vec4(0.2,1.0,0.8,1.0);
=======
//vec4 tYellow = vec4(0.859,0.851,0.145,1.0);
vec4 Green = vec4(0.0,1.0,0.0,1.0);
>>>>>>> 472b42f594dde065f0dca89f468094cddfabd72f
vec4 Yellow = vec4(1.0,1.0,0.0,1.0);	
vec4 White = vec4(1.0,1.0,1.0,1.0);
vec4 Black = vec4(0.0,0.0,0.0,1.0);
vec4 Trans = vec4(0.0,0.0,0.0,0.0);
    
void main() 
{
    vec4 texel = texture(Texture, v_TexCoord).bgra;
    if (v_ColorPrimary.a == 0.0)
        out_FragColor = texel;
    else
    {
        float luma = getLuma(v_ColorPrimary.rgb);
<<<<<<< HEAD
	vec4 ipp;
        vec4 iip;
        vec4 pip;
        vec4 ipi;
	vec4 nuke;
=======
        
        vec4 pip;
        vec4 ipi;
        vec4 border;

	//vec4 nukin;
		//if (isClose(v_ColorPrimary.rgb, tYellow))
		//	nukin = Green;
		//else

	//nukin = Yellow;
>>>>>>> 472b42f594dde065f0dca89f468094cddfabd72f

	//toogle apperace between selected, unselected and mouseover
	//for body (is either ipi or pip depending on how light or dark) (basically team color) :
	vec4 body;	
<<<<<<< HEAD
	if (v_SelectedState < -1.9) 
            body = v_ColorPrimary;             //mouseover
        else if (v_SelectedState < -0.9)
            body = v_ColorPrimary;             //unselected
	else if (v_SelectedState < 1.1)
            body = White;                      //selected
        else                          
            body = White;                      //selected + mouseover (unused)

	vec4 body2;	
	if (v_SelectedState < -1.9) 
            body2 = Black;             //mouseover
        else if (v_SelectedState < -0.9)
            body2 = Drey;             //unselected
	else if (v_SelectedState < 1.1)
            body2 = Black;                      //selected
        else                          
            body2 = Black;                      //selected + mouseover (unused)

	vec4 body3;	
	if (v_SelectedState < -1.9) 
            body3 = Grey;             //mouseover
        else if (v_SelectedState < -0.9)
            body3 = White;             //unselected
	else if (v_SelectedState < 1.1)
            body3 = Grey;                      //selected
        else                          
            body3 = Grey;                      //selected + mouseover (unused)


	//tiermarker (+ ipp when color is dark) (blue or tier marker) :
	vec4 tiermarker;
	if (v_SelectedState < -1.9)
            tiermarker = Black;                //mouseover
        else if (v_SelectedState < -0.9)
            tiermarker = White;                //unselected
	else if (v_SelectedState < 1.1)
            tiermarker = White;                //selected
        else                          
            tiermarker = White;                //selected + mouseover (unused)

	vec4 tiermarker2;
	if (v_SelectedState < -1.9)
            tiermarker2 = Black;                //mouseover
        else if (v_SelectedState < -0.9)
            tiermarker2 = White;                //unselected
	else if (v_SelectedState < 1.1)
            tiermarker2 = Black;                //selected
        else                          
            tiermarker2 = Black;                //selected + mouseover (unused)

	//border (Red)
	vec4 border;
	if (v_SelectedState < -1.9)
            border = White;                     //mouseover
        else if (v_SelectedState < -0.9)
            border = Black;                     //unselected
	else if (v_SelectedState < 1.1)
            border = v_ColorPrimary;            //selected
        else                          
            border = v_ColorPrimary;            //selected + mouseover (unused)

	vec4 border2;
	if (v_SelectedState < -1.9)
            border2 = Grey;                     //mouseover
        else if (v_SelectedState < -0.9)
            border2 = Black;                     //unselected
	else if (v_SelectedState < 1.1)
            border2 = Grey;            //selected
        else                          
            border2 = Grey;            //selected + mouseover (unused)

	vec4 border3;
	if (v_SelectedState < -1.9)
            border3 = White;                     //mouseover
        else if (v_SelectedState < -0.9)
            border3 = Black;                     //unselected
	else if (v_SelectedState < 1.1)
            border3 = White;            //selected
        else                          
            border3 = White;            //selected + mouseover (unused)



	//and highlight (black): 
        vec4 highlight;
        if (v_SelectedState < -1.9)
            highlight = Trans;                 //mouseover
        else if (v_SelectedState < -0.9)
            highlight = Trans;                 //unselected
	else if (v_SelectedState < 1.1)
            highlight = v_ColorPrimary;        //selected
        else                          
            highlight = v_ColorPrimary;        //selected + mouseover (unused)

        vec4 highlight2;
        if (v_SelectedState < -1.9)
            highlight2 = Trans;                 //mouseover
        else if (v_SelectedState < -0.9)
            highlight2 = Trans;                 //unselected
	else if (v_SelectedState < 1.1)
            highlight2 = Grey;        //selected
        else                          
            highlight2 = Grey;        //selected + mouseover (unused)

        vec4 highlight3;
        if (v_SelectedState < -1.9)
            highlight3 = Trans;                 //mouseover
        else if (v_SelectedState < -0.9)
            highlight3 = Trans;                 //unselected
	else if (v_SelectedState < 1.1)
            highlight3 = White;        //selected
        else                          
            highlight3 = White;        //selected + mouseover (unused)


=======
	if (v_SelectedState > 0.9) 
            body = White;               //selected
        else if (v_SelectedState > 0.4)
            body = v_ColorPrimary;      //unselected
        else                          
            body = Green;      //mouseover

	//tiermarker (+ border when color is dark) (blue or tier marker) :
	vec4 tiermarker;
	if (v_SelectedState > 0.9)
            tiermarker = Black;         //selected
        else if (v_SelectedState > 0.4)
            tiermarker = White;         //unselected
        else                          
            tiermarker = Green;         //mouseover

	//outer (Red)
	vec4 outer;
	if (v_SelectedState > 0.9)
            outer = v_ColorPrimary;     //selected
        else if (v_SelectedState > 0.4)
            outer = Black;              //unselected
        else                          
            outer = White;              //mouseover

	//and highlight (black): 
        vec4 highlight;
        if (v_SelectedState > 0.9)
            highlight = v_ColorPrimary; //selected
        else if (v_SelectedState > 0.4)
            highlight = Trans;          //unselected
        else                          
            highlight = Green; //mouseover
>>>>>>> 472b42f594dde065f0dca89f468094cddfabd72f



	// gauge closeness of team color to black
<<<<<<< HEAD
	// if team color is too dark invert ipp color and tier two marker color
	if (luma > 0.60)
	{ 
            pip = tiermarker;  //this is for yellow only : normal color sheme except for the nuke
            ipi = body;         // 
            ipp = border;     // 
	    iip = highlight;
	    nuke = Green;
        }
        else if (luma > 0.50)
	{
            pip = tiermarker2;   //this is white's color sheme alone (normal but v_ColorPrimary replaced with white)
            ipi = body3;        //
            ipp = border3;      //
	    iip = highlight3;
	    nuke = Yellow;
	}
	else if (luma > 0.12)
	{ 
            pip = tiermarker;   // red, light-blue, pink, organge 100% normal sheme 
            ipi = body;         // 
            ipp = border;     // 
	    iip = highlight;
	    nuke = Yellow;
        }
	else if (luma > 0.07)
        {
            pip = tiermarker2;   // this is purple dark blue and brown sheme (inverted border)
            ipi = border;        // 
            ipp = body;      // 
	    iip = highlight;
	    nuke = Yellow;
        }
        else
	{
            pip = tiermarker2;   // this is black's color sheme alone (inverted border + extras)
            ipi = body2;       //
            ipp = border2;       // 
	    iip = highlight2;
	    nuke = Yellow;
	}

		       	              //black,   white, red,  green, blue,yellow,magenta,cyan (NEVER USE CYAN, CYAN HATES YOU)
        vec4 color = combo(texel.rgb, iip, Black, ipp, White, pip, ipi, nuke, Black);
        color.a = color.a * texel.a;
        // the above can be changed to, for instance,
        // color.a = color.a * texel.a;
=======
        if (luma > 0.12)// if team color is too dark invert border color and tier two marker color
        { 
            pip = White;        // in this mode tiermarker (pip (blue) stays white whether selected, mousover or unselected) 
            ipi = body;         // ipi (yellow) receives body color
            border = outer;     // border (red) recieves outer color
        }
        else
        {
            pip = tiermarker;   // in this mode pip becomes addapts to the color of the border accordignly
            ipi = outer;        // ipi (yellow) recieves outer color
            border = body;      // border (red) recieves body color
        }
                                                    //nukin
		       	              //black,   white, red,  green, blue,yellow,magenta,cyan (NEVER USE CYAN, CYAN HATES YOU)
        vec4 color = combo(texel.rgb, highlight, Black, border, White, pip, ipi, Yellow, Black);
        color.a = color.a * texel.a;
        // the above can be changed to, for instance,
        // color.a = color.a * texel.a;

>>>>>>> 472b42f594dde065f0dca89f468094cddfabd72f
        // for transparent icons
        out_FragColor = color;
    }
}
