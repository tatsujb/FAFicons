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


//vec4 tYellow = vec4(0.859,0.851,0.145,1.0);
vec4 Green = vec4(0.0,1.0,0.0,1.0);
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
        
        vec4 pip;
        vec4 ipi;
        vec4 border;

	//vec4 nukin;
		//if (isClose(v_ColorPrimary.rgb, tYellow))
		//	nukin = Green;
		//else

	//nukin = Yellow;

	//toogle apperace between selected, unselected and mouseover
	//for body (is either ipi or pip depending on how light or dark) (basically team color) :
	vec4 body;	
    if (v_SelectedState > 1.4)
            body = White;                        //selected + mouseover
        else if (v_SelectedState > 0.9)
            body = v_ColorPrimary;      //selected
        else                        
            body = Green;                         //unselected

    //tiermarker (+ border when color is dark) (blue or tier marker) :
    vec4 tiermarker;
    if (v_SelectedState > 1.4)
            tiermarker = Black;                //selected + mouseover
        else if (v_SelectedState > 0.9)
            tiermarker = White;               //selected
        else                        
            tiermarker = Green;               //unselected

    //outer (Red)
    vec4 outer;
    if (v_SelectedState > 1.4)
            outer = v_ColorPrimary;       //selected + mouseover
        else if (v_SelectedState > 0.9)
            outer = Black;                           //selected
        else                        
            outer = White;                          //unselected

    //and highlight (black):
        vec4 highlight;
        if (v_SelectedState > 1.4)
            highlight = v_ColorPrimary;  //selected + mouseover
        else if (v_SelectedState > 0.9)
            highlight = Trans;                     //selected
        else                        
            highlight = Green;                    //unselected



	// gauge closeness of team color to black
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

        // for transparent icons
        out_FragColor = color;
    }
}
