using Xunit;

namespace Infrastructure.CDKTF{
    // The tests below are example tests, you can find more information at
    // https://cdk.tf/testing
    public class TestProgram{
        
        [Fact]
        public void myAppTest(){
            Assert.True(true);
        }

        //[Fact]
        //public void CheckValidity(){
        //    TerraformStack stack = new TerraformStack(Testing.EnvironmentApp(), "stack");
        //    MyApplicationsAbstraction appAbstraction = new MyApplicationsAbstraction(stack, "construct");
        //    Assert.True(Testing.ToBeValidTerraform(Testing.FullSynth(stack)) );
        //}

        //[Fact]
        //public void shouldContainContainer(){
        //    TerraformStack stack = new TerraformStack(Testing.EnvironmentApp(), "stack");
        //    MyApplicationsAbstraction appAbstraction = new MyApplicationsAbstraction(stack, "construct");
        //    string synthesized = Testing.Synth(stack);
        //    Assert.True(Testing.ToHaveResource(synthesized, Container.TfResourceType) );
        //}

        //[Fact]
        //public void shouldUseUbuntuImage(){
        //    TerraformStack stack = new TerraformStack(Testing.EnvironmentApp(), "stack");
        //    MyApplicationsAbstraction appAbstraction = new MyApplicationsAbstraction(stack, "construct");
        //    string synthesized = Testing.Synth(stack);
        //    Assert.True(Testing.ToHaveResourceWithProperties(synthesized, Image.TfResourceType, new Dictionary<String, Object>() {
        //       {"name", "ubuntu:latest"}
        //    }) );
        //}
    }

}