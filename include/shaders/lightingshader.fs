#version 330 core

in vec2 Texcoord;
in vec3 FragPos;  
in vec3 Normal;  

out vec4 FragColor;

struct Material {
    
    sampler2D texture_diffuse1;
    sampler2D texture_specular1;
    sampler2D texture_height1;
    sampler2D texture_normal1;    
    sampler2D texture_roughness1;    
    float shininess;
}; 

struct Light {
    vec3 position;
    vec3 direction;
    float cutoff;
    float outerCutOff;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float constant;
    float linear;
    float quadratic;
};
  
uniform vec3 viewPos;
uniform samplerCube skybox;
uniform Material material;
uniform Light light;


void main()
{
    // ambient
    vec3 ambient = light.ambient * vec3(texture(material.texture_height1, Texcoord));
    // diffuse
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * vec3(texture(material.texture_diffuse1, Texcoord));
    // specular
    vec3 viewDir = normalize(FragPos - viewPos);
    vec3 reflectDir = reflect(viewDir, norm);  
    //float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    //vec3 specular = light.specular * vec3(texture(material.texture_specular1, Texcoord));
    vec3 tempspecular = vec3(texture(skybox, reflectDir));
    // normal 
    vec3 texNormal = vec3(1.0f) * vec3(texture(material.texture_normal1, Texcoord));
    //roughness
    vec3 roughness = vec3(1.0f) * vec3(texture(material.texture_roughness1, Texcoord));
           
    vec3 result = ambient + diffuse + tempspecular;
    FragColor = vec4(result, 1.0);
    
    
    
} 